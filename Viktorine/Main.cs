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
using Viktorine.Models;

namespace Viktorine
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            updateView();
            UpdCategory();
        }
        void UpdCategory()
        {
            comboBox1.Items.Clear();
            SingleTon.DB.Categories.Load();
            comboBox1.Items.AddRange(SingleTon.DB.Categories.ToArray());
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
            UpdCategory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Не выбрана категория");
                return;
            }
            SingleTon.Category = comboBox1.SelectedItem as Category;
            Victory victory = new();
            victory.ShowDialog();
        }
    }
}
