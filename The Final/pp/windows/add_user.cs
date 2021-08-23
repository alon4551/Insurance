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
    public partial class add_user : System.Windows.Forms.Form
    {
        public add_user()
        {
            InitializeComponent();
        }

        private void new_person_Click(object sender, EventArgs e)
        {
            List<object> values = new List<object>(){
                id_box.Text,
                first_name.Text,
                last_name.Text,
                phone_number.Text,
                e_mail.Text,
                dateTimePicker1.Value.ToShortDateString(),
                gender.Text
            };
            string query=SQL_Queries.Insert("people",values);
            if(Access.Execute(query))
            {
               MessageBox.Show("entered");
       
            }
            else
            {
                MessageBox.Show(Access.ExplaindError());
            }
            this.Close();

        }
    }
}
