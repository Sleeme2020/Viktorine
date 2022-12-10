using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viktorine.Models
{    
    public class Quote
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<VariableQuote> VariableQuotes { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public override string ToString()
        {
            return $"{Question} - {VariableQuotes.Count}";
        }

    }
}
