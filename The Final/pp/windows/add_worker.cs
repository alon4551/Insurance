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
    public partial class add_worker : Form
    {
        public add_worker()
        {
            InitializeComponent();
        }

        private void add_worker_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private bool validation()
        {
            if ((id_worker.Text.Length != 9)|| (password_worker.Text != password_again.Text))
            {
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validation())
                return;

            List<object> values = new List<object>()
            {
                id_worker.Text,
                user_worker.Text,
                password_worker.Text,
                false
            };

            string query = SQL_Queries.Insert("workers", values);
            if (Access.Execute(query))
            {
                MessageBox.Show("inserted");
            }
            else MessageBox.Show(Access.ExplaindError());

                    
        }
    }
}
