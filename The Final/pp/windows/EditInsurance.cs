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
    public partial class EditInsurance : Form
    {
        Insurance insurance;
        List<Question> Questions;
        Question question = new Question();
        public EditInsurance(int id)
        {
            InitializeComponent();
            if (id == -1)
            {
                insurance = new Insurance();
                insurance.ID = utils.getLestId("insurance") + 1;
            }
            else
            {
                insurance = new Insurance(id);
                Questions = insurance.Questions;
                Load_Insurance();
            }
            Clear_Screen();

        }
        private void Load_Insurance()
        {
            Insurance_Name.Text = insurance.Name;
            numericUpDown2.Value = insurance.Years_Expire;
            numericUpDown4.Value = insurance.Discount;
            textBox1.Text = insurance.Price.ToString();
            utils.Load_List(Questions_Box, utils.GetNames(Questions));

        }
        public void Clear_Screen()
        {
            Question_Box.Text = "";
            Date_Limit_Box.Text = "";
            answers_list.Items.Clear();
            Answers_Box.Text = "";
            foreach (RadioButton btn in table_limit.Controls.OfType<RadioButton>())
                btn.Checked = false;
            answers_list.BackColor = Color.LightGray;
            Date_Limit_Box.Enabled = false;
            table_limit.Enabled = false;
            Date_List_Table.Enabled = false;
            Date_Price_Table.Enabled = false;
            answers_price_list.Items.Clear();
            Date_price_list.Items.Clear();
            Answers_list_Table.Enabled = false;
            Answers_Price_table.Enabled = false;
            table_multianswers.Enabled = false;
            table_buttons.Enabled = false;
        }
        public void Display_Type_Question(int type)
        {
            Clear_Screen();
            table_buttons.Enabled = true;
            switch (type)
            {
                case 1:
                    table_limit.Enabled = true;
                    Null_Limit.Checked = true;
                    break;
                case 2:
                    table_multianswers.Enabled = true;
                    answers_list.BackColor = Color.White;

                    break;
                case 3:
                    Date_List_Table.Enabled = true;
                    Date_Price_Table.Enabled = true;
                    Date_Limit_Box.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void Open_Question_CheckedChanged(object sender, EventArgs e)
        {
            Display_Type_Question(1);
            question.Type = 1;

        }

        private void Multi_Question_CheckedChanged(object sender, EventArgs e)
        {
            Display_Type_Question(2);
            question.Type = 2;

        }

        private void Date_Question_CheckedChanged(object sender, EventArgs e)
        {
            Display_Type_Question(3);
            question.Condition.Type = 5;
            question.Type = 3;
        }

        private void EditInsurance_Load(object sender, EventArgs e)
        {

        }

        private void Questions_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Questions_Box.SelectedIndex == -1)
            {
                Clear_Screen();
                return;
            }

            question.Copy(Questions[Questions_Box.SelectedIndex]);
            switch (question.Type)
            {
                case 1:
                    {
                        Open_Question.Checked = true;
                        table_limit.Enabled = true;
                        if (question.Condition != null)
                            switch (question.Condition.Type)
                            {
                                case -1:
                                    No_Limit.Checked = true;
                                    break;
                                case 0:
                                    Null_Limit.Checked = true;
                                    break;
                                case 1:
                                    ID_Limit.Checked = true;
                                    break;
                                case 2:
                                    CellPhone_Limit.Checked = true;
                                    break;
                                case 3:
                                    LocalPhone_Limit.Checked = true;
                                    break;
                                case 4:
                                    Email_Limit.Checked = true;
                                    break;
                                case 5:
                                    break;

                            }
                        else
                            No_Limit.Checked = true;
                        break;
                    }
                case 2:

                    Multi_Question.Checked = true;
                    table_multianswers.Enabled = true;
                    answers_list.Enabled = true;
                    utils.Load_List(answers_list, utils.GetNames(question.Answers));
                    //------------------------------------------
                    Answers_list_Table.Enabled = true;
                    Answers_Price_table.Enabled = true;
                    utils.Load_List(answers_price_list, utils.GetNames(question.Answers));
                    break;
                case 3:
                    Date_List_Table.Enabled = true;
                    Date_Price_Table.Enabled = true;
                    //---------------------------------
                    Date_Question.Checked = true;
                    Date_Limit_Box.Text = question.Condition.Limit.ToString();
                    utils.Load_List(Date_price_list, utils.GetNames(question.Condition.Dates));

                    break;
            }
            table_buttons.Enabled = true;
            Question_Box.Text = question.Q;

        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox box = (ListBox)sender;

            if (box.SelectedIndex == -1)
            {

                return;
            }
            Answers_Box.Text = answers_list.SelectedItem.ToString();
            if (box.SelectedIndex == question.getDetailIndex())
                Is_Detail.Checked = true;
            else
                Is_Detail.Checked = false;
        }

        private void Answers_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (answers_list.SelectedIndex != -1)
                {
                    answers_list.Items[answers_list.SelectedIndex] = Answers_Box.Text;
                    question.Answers[answers_list.SelectedIndex].Answer = Answers_Box.Text;
                }
                else
                    Add_Option_Click(null, null);
                answers_list.ClearSelected();
            }
        }

        private void Is_Detail_CheckedChanged(object sender, EventArgs e)
        {
            if (answers_list.SelectedIndex == -1)
            {
                return;
            }
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
            {
                question.SetAmericanDetail(answers_list.SelectedIndex, true);
            }
            else if (Is_Detail.Checked == false && answers_list.SelectedIndex == question.getDetailIndex())
            {
                question.SetAmericanDetail(answers_list.SelectedIndex, false);
            }
        }

        private void Date_Limit_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Option_Click(object sender, EventArgs e)
        {
            answers_list.Items.Add(Answers_Box.Text);
            if (Is_Detail.Checked)
            {
                question.Add_American_Answer(Answers_Box.Text, true);
            }
            answers_list.ClearSelected();
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (answers_list.SelectedIndex == -1)
            {
                return;
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                question.Remove_American_Answer(answers_list.SelectedIndex);
                answers_list.Items.RemoveAt(answers_list.SelectedIndex);
                answers_list.SelectedIndex = -1;
            }
        }

        private void Date_Limit_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                try
                {
                    if (Date_Limit_Box.Text == "" || int.Parse(Date_Limit_Box.Text) <= 0)
                    {
                        question.Condition = new Question_Condition(0, "אין הגבלה", 0);
                        return;
                    }
                    if (question.Condition != null)
                        question.Condition.Limit = int.Parse(Date_Limit_Box.Text);
                    else
                    {
                        DateTime t = DateTime.Now;
                        t.AddYears(-int.Parse(Date_Limit_Box.Text));
                        question.Condition = new Question_Condition(5, "השתמש בתאריך מוקדם יותר " + t.ToShortDateString(), int.Parse(Date_Limit_Box.Text));
                    }

                }
                catch
                {
                    MessageBox.Show("רק מספרים בבקשה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void No_Limit_CheckedChanged(object sender, EventArgs e)
        {
            question.Condition.Type = -1;
        }

        private void Null_Limit_CheckedChanged(object sender, EventArgs e)
        {
            question.Condition.Type = 0;
        }

        private void ID_Limit_CheckedChanged(object sender, EventArgs e)
        {
            question.Condition.Type = 1;
        }

        private void CellPhone_Limit_CheckedChanged(object sender, EventArgs e)
        {
            question.Condition.Type = 2;
        }

        private void LocalPhone_Limit_CheckedChanged(object sender, EventArgs e)
        {
            question.Condition.Type = 3;
        }

        private void Email_Limit_CheckedChanged(object sender, EventArgs e)
        {
            question.Condition.Type = 4;
        }

        private void Answers_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void Update_Question_Click(object sender, EventArgs e)
        {
            question.Q = Question_Box.Text;
            Questions[Questions_Box.SelectedIndex].Copy(question);
            Clear_Screen();
            Load_Insurance();
        }

        private void Delete_Question_Click(object sender, EventArgs e)
        {

            for (int index = Questions_Box.SelectedIndex + 1; index < Questions.Count; index++)
            {
                Questions[index].Order--;
            }
            Questions.RemoveAt(Questions_Box.SelectedIndex);
            Questions_Box.ClearSelected();
            Clear_Screen();
            Load_Insurance();
        }

        private void Add_Question_Click(object sender, EventArgs e)
        {
            SaveAnswer();
            Questions.Add(question);
            question = new Question();

            Clear_Screen();
            Load_Insurance();

        }
        private void SaveAnswer()
        {
            question.ID = utils.getLestId("question") + 1;
            question.Order = Questions.Count;
            question.Q = Question_Box.Text;
            question.Order = Questions.Count;
            if (Open_Question.Checked)
                question.Type = 1;
            else if (Multi_Question.Checked)
                question.Type = 2;
            else if (Date_Question.Checked)
                question.Type = 3;
            switch (question.Type)
            {
                case 1:
                    if (No_Limit.Checked)
                        question.Condition.Type = 0;
                    if (ID_Limit.Checked)
                        question.Condition.Type = 1;
                    if (CellPhone_Limit.Checked)
                        question.Condition.Type = 2;
                    if (LocalPhone_Limit.Checked)
                        question.Condition.Type = 3;
                    if (Email_Limit.Checked)
                        question.Condition.Type = 4;
                    break;
                case 2:
                    break;
                case 3:
                    question.Condition.Type = 5;
                    try
                    {
                        question.Condition.Limit = int.Parse(Date_Limit_Box.Text);
                    }
                    catch
                    {

                    }
                    break;
            }
        }
        private void Question_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                question.Q = Question_Box.Text;
            }
        }

        private void Date_Limit_Box_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (Date_Limit_Box.Text != "")
                    question.Condition.Limit = int.Parse(Date_Limit_Box.Text);
            }
            catch
            {
                MessageBox.Show("רק מספרים בבקשה");
                Date_Limit_Box.Text = "";
            }
        }

        private void Insurance_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                insurance.Name = Insurance_Name.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void UpArrow_Click(object sender, EventArgs e)
        {
            if (Questions_Box.SelectedIndex > 0)
            {
                int index = Questions_Box.SelectedIndex;
                Questions[Questions_Box.SelectedIndex].Order--;
                Questions[Questions_Box.SelectedIndex - 1].Order++;
                Questions = utils.OrginazeQuestions(Questions);
                Clear_Screen();
                Load_Insurance();
                Questions_Box.SelectedIndex = index - 1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Questions_Box.SelectedIndex < Questions.Count - 1)
            {
                int index = Questions_Box.SelectedIndex;
                Questions[Questions_Box.SelectedIndex].Order++;
                Questions[Questions_Box.SelectedIndex + 1].Order--;
                Questions = utils.OrginazeQuestions(Questions);
                Clear_Screen();
                Load_Insurance();
                Questions_Box.SelectedIndex = index + 1;
            }
        }

        private void Question_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void answers_price_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            american_price.Text = question.Answers[answers_price_list.SelectedIndex].Price.ToString();
        }

        private void Add_American_Price_Click(object sender, EventArgs e)
        {
            try
            {
                if (american_price.Text == "")
                {
                    question.SetPrice(answers_price_list.SelectedIndex, 0);
                    return;
                }

                if (int.Parse(american_price.Text) >= 0)
                    question.SetPrice(answers_price_list.SelectedIndex, int.Parse(american_price.Text));
                else
                    MessageBox.Show("סכום גדול או שווה ל0");
            }
            catch
            {
                MessageBox.Show("רק מספרים בבקשה");
            }
        }

        private void Date_price_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            range.Text = question.Condition.Dates[Date_price_list.SelectedIndex].Range.ToString();
            min_date.Text = question.Condition.Dates[Date_price_list.SelectedIndex].Limit.ToString();
            date_price.Text = question.Condition.Dates[Date_price_list.SelectedIndex].Price.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            question.Condition.AddDateCondition(int.Parse(min_date.Text), int.Parse(range.Text), int.Parse(date_price.Text));
            utils.Load_List(Date_price_list, utils.GetNames(question.Condition.Dates));

        }

        private void button7_Click(object sender, EventArgs e)
        {
            question.Condition.UpdateDateCondition(Date_price_list.SelectedIndex, min_date.Text, range.Text, date_price.Text);
            utils.Load_List(Date_price_list, utils.GetNames(question.Condition.Dates));
        }

        private void answers_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (answers_list.SelectedIndex == -1) return;
            Answers_Box.Text = question.Answers[answers_list.SelectedIndex].Answer;
            Is_Detail.Checked = false;
            if (answers_list.SelectedIndex == question.getDetailIndex())
                Is_Detail.Checked = true;
        }


        private void Add_Option_Click_1(object sender, EventArgs e)
        {
            question.Add_American_Answer(Answers_Box.Text, Is_Detail.Checked);
            Clear_Screen();
            Load_Insurance();
        }

        private void Answers_Box_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                question.Answers[answers_list.SelectedIndex].Answer = Answers_Box.Text;
                question.SetAmericanDetail(answers_list.SelectedIndex, Is_Detail.Checked);
                answers_list.ClearSelected();
                utils.Load_List(answers_list, utils.GetNames(question.Answers));
                utils.Load_List(answers_price_list, utils.GetNames(question.Answers));
            }
        }

        private void Date_Limit_Box_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    question.Condition.Limit = int.Parse(Date_Limit_Box.Text);
                }
                catch
                {
                    MessageBox.Show("אך ורק מספרים בבקשה");
                }
            }
        }

        private void Question_Box_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                question.Q = Question_Box.Text;
            }
        }

        private void answers_list_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                question.Remove_American_Answer(answers_list.SelectedIndex);
                answers_list.Items.RemoveAt(answers_list.SelectedIndex);
            }
        }

        private void Insurance_Name_TextChanged(object sender, EventArgs e)
        {
            insurance.Name = Insurance_Name.Text;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            insurance.Years_Expire =(int)numericUpDown2.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                    insurance.Price = int.Parse(textBox1.Text);
                else
                    insurance.Price = 0;
            }
            catch
            {

            }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                
                insurance.Discount = (int)numericUpDown4.Value;
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            insurance.Questions = Questions;
            if (insurance.Update())
                MessageBox.Show("ביטוח עודכן");
            else
                MessageBox.Show(Access.ExplaindError());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insurance.Questions = Questions;
            if (insurance.Save())
                MessageBox.Show("ביטוח נכנס");
            else
                MessageBox.Show(Access.ExplaindError());
        }
    }
}
