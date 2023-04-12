using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Beer
    {
        public int ID {set; get; }
        public string Title { set; get; }
        public string Alchool { set; get; }
        public string Description { set; get; }

        public string Country { set; get; }

        public override string ToString()
        {
            return Title;
        }

    }
}
