using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pp
{
    public partial class questions : Form
    {
        public Insurance insurance;
        List<Question> Questions;
        public int index = 0,insurance_id,customer_id,type;
        public questions(int customer,int t)
        {
            InitializeComponent();
            insurance_id = utils.getLestId("people_insurances") + 1;
            customer_id = customer;
            insurance = new Insurance(t);
            Questions = insurance.Questions;
        }
        public questions()
        {
            InitializeComponent();
        }

        private void qustions_Load(object sender, EventArgs e)
        {
            Type_Qustion();
            label2.Text = "";

        }
        private void Type_Qustion() //מציג את הנראות של השאלה  
        {
        
            Clear_screen();
            label1.Text = $"{index+1}/{Questions.Count}";
            question.Text = Questions[index].Q;
            object ans = Questions[index].Answer;
            
            try
            {
                switch (Questions[index].Type)
                {
                    case 1:
                        {
                            answer.Visible = true;
                            if (ans != null)
                                answer.Text = ans.ToString();
                            else
                                answer.Text = "";
                            break;
                        }
                    case 2:
                        {
                            MultipleRadioButtons(Questions[index]);
                            break;
                        }

                    case 3:
                        {
                            datepicker.Visible = true;
                            if (ans != null)
                                datepicker.Value = DateTime.Parse(ans.ToString());
                            else
                                datepicker.Value = datepicker.MinDate;
                            break;
                        }

                }
            }
            catch
            {

            }
        }
        private void Clear_screen()// מאפס את הנראות 
          
        {
            foreach (object box in groupBox1.Controls)
            {
                switch (box.GetType().Name)
                {
                    case "Label":
                        break;
                    case "TextBox":
                        {
                            ((TextBox)box).Visible=false;
                            break;
                        }
                    case "ListBox":
                        {
                            ((ListBox)box).Visible = false;
                            break;
                        }
                    case "RadioButton":
                        {
                            ((RadioButton)box).Visible = false;
                            break;
                        }
                    case "DateTimePicker":
                        {
                            ((DateTimePicker)box).Visible = false;
                            break;
                        }
                    case "PictureBox":
                        {
                            ((PictureBox)box).Visible = false;
                            break;
                        }

                }
             
                    
            }
        }
        private void Clear_RadioButtons()//מנקה כפתורי אפשרויות 
        {
            for (int i = 0; i <groupBox1.Controls.Count; i++)
                if (groupBox1.Controls[i].GetType().Name == "RadioButton")
                    groupBox1.Controls.RemoveAt(i);

        }
        private void MultipleRadioButtons(Question qustion)// מציג את כפתורי השאלה 
        {
            Clear_RadioButtons();
            detail.Visible = qustion.IsDetail();
            object ans = qustion.Answer;
            for (int i = 0; i < qustion.Answers.Count; i++)
            {
                RadioButton btn = new RadioButton();
                btn.Name = "Option" + i;//change to answer id number is accdb table
                btn.Location = new Point(groupBox1.Width/2, groupBox1.Height/10 + i * 20);
                btn.Text = qustion.Answers[i].Answer;
                
                if (ans != null && btn.Text == ans.ToString())
                    btn.Checked = true;
                btn.Anchor = AnchorStyles.Right;
                btn.CheckAlign = ContentAlignment.MiddleRight;
                btn.AutoSize = true;
                if (i == qustion.getDetailIndex())
                {
                    detail.Location= new Point(groupBox1.Width / 2 - detail.Width-20, groupBox1.Height / 10 + i * 20);
                    if(ans!=null)
                        detail.Text = ans.ToString();
                    btn.CheckedChanged += radio_click;
                }
                groupBox1.Controls.Add(btn);
            }
        }
        private void radio_click(object sender,EventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            detail.Enabled = btn.Checked;

        }
        private void SaveAnswer()
        {
            
            switch (Questions[index].Type)
            {
                case 1:
                   
                    Questions[index].SetAnswer(answer.Text);
                    break;
                case 2:
                    foreach(RadioButton button in Controls.OfType<RadioButton>())
                        if(button.Checked)
                            Questions[index].SetAnswer(button.Text);
                    break;
                case 3:
                    Questions[index].SetAnswer(datepicker.Value.ToShortDateString());
                    break;
            }
        }
         private bool ValidateInput()
        {
            
            if(Questions[index].Condition!=null)
            {
                if (Questions[index].Condition.Type < 4)
                    if (utils.Check(Questions[index].Condition.Type, answer.Text))
                        return true;
                    else
                    {
                        MessageBox.Show(Questions[index].Condition.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        label2.Text = Questions[index].Condition.Message;
                        return false;
                    }
                else if (Questions[index].Condition.Type == 5)
                {
                    if (utils.Check( datepicker.Value.ToShortDateString(),Questions[index].Condition.Limit))
                        return true;
                    else
                    {
                        MessageBox.Show(Questions[index].Condition.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        label2.Text = Questions[index].Condition.Message;
                        return false;
                    }
                }
            }
            if (Questions[index].Type==2)
            {
                foreach (RadioButton btn in groupBox1.Controls.OfType<RadioButton>())
                {
                    if (btn.Checked)
                        return true;
                }
                MessageBox.Show("אנא בחר אחד מהאפשריות", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void Save()
        {
            List<object> values = new List<object>()
            {
                insurance_id,
                customer_id,
                type
            };
            if (Access.Execute(SQL_Queries.Insert("people_insurances", values)) == false)
                MessageBox.Show(Access.ExplaindError());
            foreach(Question q in Questions)
            {
                values = new List<object>()
                {
                    insurance_id,
                    q.ID,
                    q.Answer.ToString()
                };
                if (Access.Execute(SQL_Queries.Insert("people_answers", values)) == false)
                    MessageBox.Show(Access.ExplaindError());
            }
                        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (index >= Questions.Count - 1)
            {
                DialogResult result = MessageBox.Show("השאלון הסתיים, האם אתה בטוח שאתה סיימת?","סיום שאלון",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                SaveAnswer();
                if(result==DialogResult.Yes)
                {

                    this.Close();
                }
                //save answers

                return;
            }
            if (ValidateInput())
            {
                SaveAnswer();
                index++;
                Type_Qustion();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (index <= 0 )
                return;
                index--;
                Type_Qustion();
        }
    }
}
