using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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
    public partial class Victory : Form
    {
        Victorine victorine;
        Quote[] Quotes;
        int index = 0;
        public Victory()
        {
            InitializeComponent();
            victorine = new Victorine()
            {
                Category = SingleTon.Category,
                User = SingleTon.User,
                Date = DateTime.Now,
                VictorineQuotes = new()
            };
            Quotes = SingleTon.DB.Quotes.Include(u=>u.VariableQuotes)
                .Where(u => u.Category == SingleTon.Category)
                .ToArray();
        }




        private void Victory_Shown(object sender, EventArgs e)
        {
            NextQuestions();
        }

        void GenerateVarQuotes(Quote quote)
        {
            panel1.Controls.Clear();
            int i = 1;
            foreach(var varq in quote.VariableQuotes)
            {
                var radioButton1 = new RadioButton();
                radioButton1.AutoSize = true;
                radioButton1.Location = new Point(20, 25*i);
                radioButton1.Name = $"radioButton{i}";
                radioButton1.Tag = varq;
                radioButton1.Size = new System.Drawing.Size(94, 19);
                radioButton1.TabIndex = 0;
                radioButton1.TabStop = true;
                radioButton1.Text = varq.Name;
                radioButton1.UseVisualStyleBackColor = true;
                panel1.Controls.Add(radioButton1);
                i++;
            }
        }



        void NextQuestions()
        {
            if(Quotes.Length>index)
            {
                linkLabel1.Text= Quotes[index].Question;
                GenerateVarQuotes(Quotes[index]);
                index++;
            }
            else
            {
                SingleTon.DB.Add(victorine);
                SingleTon.DB.SaveChanges();
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VariableQuote? variableQuote = null;
            foreach( var cont in panel1.Controls)
            {
                if(cont is RadioButton)
                {
                    RadioButton radioButton = (RadioButton)cont;
                    if(radioButton.Checked)
                        variableQuote = (VariableQuote)radioButton.Tag;

                }
            }

            VictorineQuote victorineQuote = new()
            {
                Victorine = this.victorine,
                Quote = Quotes[index-1],
                VariableQuoteVictory = variableQuote,
                IsPrived = variableQuote.IsPrived
            };
            victorine.VictorineQuotes.Add(victorineQuote);



            NextQuestions();
        }
    }
}
