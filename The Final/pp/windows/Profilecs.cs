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
    public partial class Profilecs : System.Windows.Forms.Form
    {
        public Profilecs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = SQL_Queries.Select("people", new Condition("ID", textBox1.Text));
            string query2 = SQL_Queries.Select("insurance", new Condition("person_id", textBox1.Text));
            List<Row> table = Access.getObjects(query);
            List<Row> insurances = Access.getObjects(query2);
            if (table != null)
            {
                if (table.Count != 0)
                {
                    Fill_data(table[0]);
                    Fill_insurance(insurances);
                }
                else
                    MessageBox.Show("not found");

            }
            else
            {
                MessageBox.Show(Access.ExplaindError());
            }
        }

        private void Fill_insurance(List<Row> table)
        {
            listBox1.Items.Clear();
            if (table == null||table.Count==0)
            {
                return;
            }
            foreach(Row row in table)
            {
                listBox1.Items.Add(row.GetColValue("TYPE_NAME").ToString());
            }
        }

        private void Fill_data(Row row)
        {
                id_user.Text = row.GetColValue("ID").ToString();
                first_name.Text = row.GetColValue("FIRST_NAME").ToString();
                last_name.Text = row.GetColValue("LAST_NAME").ToString();
                phone_number.Text = row.GetColValue("PHONE").ToString();
                e_mail.Text = row.GetColValue("EMAIL").ToString();
                sex.Text = row.GetColValue("GENDER").ToString();
                dateTimePicker1.Value = DateTime.Parse(row.GetColValue("BIRTHDAY").ToString());
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Col> values = new List<Col>()
            {
                new Col("ID",id_user.Text),
                new Col("FIRST_NAME",first_name.Text),
                new Col("LAST_NAME",last_name.Text),
                new Col("PHONE",phone_number.Text),
                new Col("EMAIL",e_mail.Text),
                new Col("GENDER",sex.Text),
                new Col("BIRTHDAY",dateTimePicker1.Value.ToShortDateString())
            };
            string query = SQL_Queries.Update("people", values, new Condition("ID", textBox1.Text));
            if (Access.Execute(query))
                MessageBox.Show("עודכן");
            else
                MessageBox.Show(Access.ExplaindError());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = SQL_Queries.Delete("people", new Condition("ID", textBox1.Text));
            if (Access.Execute(query))
                MessageBox.Show("נמחק");
            else
                MessageBox.Show(Access.ExplaindError());
        }
    }
}
