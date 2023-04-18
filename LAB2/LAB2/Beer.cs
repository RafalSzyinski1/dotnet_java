using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    internal class Beer
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string alchool { get; set; }
        public string description { get; set; }
        public string country { get; set; }

        public override string ToString()
        {
            return title + " - " + alchool + " - " + description;
        }
    }
}
