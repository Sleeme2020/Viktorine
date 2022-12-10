using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viktorine.Models
{
    public class Victorine
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Users User { get; set; }
        public int UserId { get; set; }
        public List<VictorineQuote> VictorineQuotes { get; set; }
        public Category Category { get; set; }
        public int CategoryId   { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Date} очков {VictorineQuotes?.Where(u=>u.IsPrived).Count()}";
        }
    }
}
