using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Beer
    {
        public string title { set; get; }
        public string alchool { set; get; }
        public string description { set; get; }

        public override string ToString()
        {
            return title;
        }

    }
}
