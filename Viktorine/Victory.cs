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
            victorine = new Victorine();
            Quotes = SingleTon.DB.Quotes.Include(u=>u.VariableQuotes)
                .Where(u => u.Category == SingleTon.Category)
                .ToArray();
        }




        private void Victory_Shown(object sender, EventArgs e)
        {

        }

        void GenerateVarQuotes(Quote quote)
        {
            panel1.Controls.Clear();
            foreach(var varq in quote.VariableQuotes)
            {

            }
        }



        void NextQuestions()
        {
            if(Quotes.Length>index)
            {
                linkLabel1.Text= Quotes[index].Question;
                GenerateVarQuotes(Quotes[index]);
            }
            else
            {

            }
        }


    }
}
