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
    public partial class main_wimdow : Form
    {
        public main_wimdow()
        {
            InitializeComponent();
        }

        private void לקוחחדשToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(add_user window =new add_user())
            {
                this.Hide();
                window.ShowDialog();
                this.Show();
            }
        }

        private void עובדחדשToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (add_user window = new add_user())
            {
                this.Hide();
                window.ShowDialog();
                
            }
            using (add_worker window =new add_worker())
            {
                window.ShowDialog();
                this.Show();
            }
        }

        private void חיפושלקוחותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Profilecs window = new Profilecs())
            {
                this.Hide();
                window.ShowDialog();
                this.Show();
            }
        }
    }
}
