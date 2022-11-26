using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viktorine
{
    public static class SingleTon
    {
        public static AppContext DB { get; set; }
        static SingleTon()
        {
            DB = new AppContext();
        }
    }
}
