using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viktorine
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(SingleTon.DB.Users.Where(u => u.Login == textBox2.Text).Count()>0)
            {
                MessageBox.Show("логин занят!");
                return;
            }

            DialogResult= DialogResult.OK;
            Close();
        }
    }
}
