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
    public partial class EditViktorine : Form
    {
        public EditViktorine()
        {
            InitializeComponent();
            UpdCategory();
            UpdQuotes();
        }

        void UpdCategory()
        {
            comboBox1.Items.Clear();
            SingleTon.DB.Categories.Load();
            comboBox1.Items.AddRange(SingleTon.DB.Categories.ToArray());
        }

        void UpdQuotes()
        {
            listBox1.Items.Clear();
            SingleTon.DB.Quotes.Load();
            if(comboBox1.SelectedItem ==null)
            {
                listBox1.Items.AddRange(SingleTon.DB.Quotes.ToArray());
                return;
            }
            listBox1.Items.AddRange
                (SingleTon.DB.Quotes.Where(
                    x=>x.Category==comboBox1.SelectedItem 
                    ).ToArray()
                );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddCategory addCategory = new AddCategory();
            if(addCategory.ShowDialog()==DialogResult.OK)
            {
                SingleTon.DB.Categories.Add(
                    new Models.Category()
                    { Name = addCategory.textBox1.Text });
                SingleTon.DB.SaveChangesAsync();
                UpdCategory();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdQuotes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem==null)
            {
                MessageBox.Show("Не выбрана категория");
                return;
            }

            Quote quote = new Quote() 
            { 
                Question = textBox1.Text,
                Category = (comboBox1.SelectedItem as Category)            
            };

            List < VariableQuote > ListVariable = new();
             for(int i=0;i<dataGridView1.RowCount;i++)
            {
                ///dataGridView1[1, i].Value
                ListVariable.Add(new()
                {
                    Quote = quote,
                    Name  = dataGridView1[1, i].Value as string,
                    IsPrived = Convert.ToBoolean(dataGridView1[2, i].Value) 

                });
            }
             quote.VariableQuotes = ListVariable;
            SingleTon.DB.Quotes.Add(quote);
            SingleTon.DB.SaveChangesAsync();
            UpdQuotes();
        }
    }
}
