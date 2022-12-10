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
            SingleTon.DB.Quotes.Include(u=>u.VariableQuotes).Load();
            if(comboBox1.SelectedItem ==null)
            {
                listBox1.Items.AddRange(SingleTon.DB.Quotes.ToArray());
                return;
            }


            var ar = SingleTon.DB.Quotes.
                Include(u => u.VariableQuotes)
                .Where(
                    x => x.Category == comboBox1.SelectedItem
                    ).ToArray();
            listBox1.Items.AddRange
                (ar);
        }

        void Clean()
        {
            textBox1.Text.Trim();
            dataGridView1.Rows.Clear();
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
                if(dataGridView1[1, i].Value as string !=null)
                ListVariable.Add(new()
                {
                    Quote = quote,
                    Name  = dataGridView1[1, i].Value as string,
                    IsPrived = Convert.ToBoolean(dataGridView1[2, i].Value) 

                });
            }
             quote.VariableQuotes = ListVariable;
            SingleTon.DB.Quotes.Add(quote);
            SingleTon.DB.SaveChanges();
            Clean();
            UpdQuotes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Не выбрана категория");
                return;
            }
            if (listBox1.SelectedItem== null)
            {
                MessageBox.Show("Не выбрана категория");
                return;
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                ///dataGridView1[1, i].Value
                if (dataGridView1[1, i].Value as string != null)
                {
                    if (dataGridView1[0, i].Value != null) {

                        var q = (listBox1.SelectedItem as Quote);
                        var varqoute = q.VariableQuotes.
                            Where(u => u.Id == (Convert.ToInt32(dataGridView1[0, i].Value)))
                            .FirstOrDefault();
                        varqoute.Name = dataGridView1[1, i].Value as string;
                        varqoute.IsPrived = Convert.ToBoolean(dataGridView1[2, i].Value);
                    }
                    else
                    {
                        (listBox1.SelectedItem as Quote).VariableQuotes.Add(
                            new()
                            {
                                Quote = (comboBox1.SelectedItem as Quote),
                                Name = dataGridView1[1, i].Value as string,
                                IsPrived = Convert.ToBoolean(dataGridView1[2, i].Value)

                            }
                            );
                    }
                }
                    //ListVariable.Add(new()
                    //{
                    //    Quote = quote,
                    //    Name = dataGridView1[1, i].Value as string,
                    //    IsPrived = Convert.ToBoolean(dataGridView1[2, i].Value)

                    //});
            }
            
            SingleTon.DB.Quotes.Update(listBox1.SelectedItem as Quote);
            SingleTon.DB.SaveChanges();
            Clean();
            UpdQuotes();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            Clean();
            textBox1.Text = (listBox1.SelectedItem as Quote).Question;
            int i = 0;
            foreach(var varqoute in (listBox1.SelectedItem as Quote).VariableQuotes)
            {                
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = varqoute.Id;
                dataGridView1[1, i].Value = varqoute.Name;
                dataGridView1[2, i].Value = varqoute.IsPrived;
                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            //var q = (listBox1.SelectedItem as Quote);
            SingleTon.DB.Remove(listBox1.SelectedItem);
            SingleTon.DB.SaveChanges();
            Clean();
            UpdQuotes();
        }
    }
}
