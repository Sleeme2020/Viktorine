using Microsoft.EntityFrameworkCore;
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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            updateView();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        public void updateView()
        {
            UpdList();
            UpdReiting();
        }

        private void UpdList()
        {
            listBox1.Items.AddRange(SingleTon.DB.Victorines
                .Where(v=>v.User==SingleTon.User)
                .Include(v=>v.VictorineQuotes)
                .ToArray()
                );


        }
        public void UpdReiting()
        {
            linkLabel1.Text = SingleTon.DB.VictorineQuotes.
                Where(u => u.Victorine.User == SingleTon.User
                && u.IsPrived).Count().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditViktorine viktorine = new EditViktorine();
            viktorine.ShowDialog();
        }
    }
}
