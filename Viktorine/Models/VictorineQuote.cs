using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viktorine.Models
{
    public class VictorineQuote
    {
        public int Id { get; set; }
        public Victorine Victorine { get; set; }
        public int VictorineId { get; set; }
        public Quote Quote { get; set; }
        public int QuoteId { get; set; }
        public VariableQuote VariableQuoteVictory { get; set; }
        public int VariableQuoteVictoryId { get; set; }
        public bool IsPrived { get; set; }       



    }
}
