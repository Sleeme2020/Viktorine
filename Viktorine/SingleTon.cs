using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viktorine.Models;

namespace Viktorine
{
    public static class SingleTon
    {
        public static Users User { get; set; }
        public static Category Category { get; set; }
        public static AppContext DB { get; set; }
        static SingleTon()
        {
            DB = new AppContext();
        }
    }
}
