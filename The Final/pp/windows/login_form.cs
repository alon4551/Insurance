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
    public partial class login_form : Form
    {
        public login_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Condition> conditions = new List<Condition>()
            {
                new Condition("ID", id_worker.Text),
                 new Condition("PASSWORD",worker_password.Text)
            };
            string query = SQL_Queries.Select("workers", conditions, "and");
            List<Row> table = Access.getObjects(query);
            if (table != null && table.Count != 0)
            {
                if (Insert_shift())
                {
                    MessageBox.Show("כניסה אושרה");
                    using (main_wimdow window = new main_wimdow())
                    {
                        this.Hide();
                        window.ShowDialog();
                        this.Show();
                    }
                }
                //insert shift
            }
            else if (table.Count == 0)

                MessageBox.Show("Not found");

            else
                MessageBox.Show(Access.ExplaindError());


        }

        private bool Insert_shift(){

            List<object> values = new List<object>()
            {
                GetShiftId(),
                id_worker.Text,
                DateTime.Now.ToShortTimeString(),
                "not",
                DateTime.Now.ToShortDateString()
            };
            string query = SQL_Queries.Insert("shifts",values);
            return Access.Execute(query);

        }

        private bool End_shift() {
            List<Condition> conditions = new List<Condition>()
            {
                new Condition("id_worker", id_worker.Text),
                 new Condition("End","not")
            };
            Row row = new Row();
            string query = SQL_Queries.Select("shifts", conditions, "and");
            List<Row> table = Access.getObjects(query);
            bool execute = true;
            if (table != null && table.Count != 0)
            {
                foreach (Row r in table)
                {
                    query = SQL_Queries.Update("shifts",
                        new List<Col>() { new Col("End", DateTime.Now.ToShortTimeString()) },
                        new Condition("id", int.Parse(r.GetColValue(0).ToString())));
                    execute &= Access.Execute(query);
                }
            }
            else
                return false;
            return execute;
        }
        private int GetShiftId()
        {
            string query = SQL_Queries.Select("shifts");
            List<Row> table = Access.getObjects(query);
            int big = -1;
            if (table!=null)
            { 
                 foreach(Row r in table)
                {
                    if (int.Parse(r.GetColValue(0).ToString()) > big)
                        big =int.Parse( r.GetColValue(0).ToString());
                }
                
                
            }
            if (big == -1)
                return 0;
            return big+1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongDateString() +"  "+ DateTime.Now.ToLongTimeString();
        }

        private void login_form_Load(object sender, EventArgs e)
        {
            timer1_Tick(null, null);
            timer1.Interval=1000;
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (End_shift())
            {
                MessageBox.Show("משמרת נגמרה");

            }
            else
                MessageBox.Show(Access.ExplaindError());
        }
    }
}
