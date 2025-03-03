using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Trash
    {
        public string Name { get; set; }
        public int Mass { get; set; }

        public Trash(string name, int mass)
        {
            Name = name;
            Mass = mass;
        }   

        public virtual string GetSpecialInfo()
        {
            return "0";
        }
    }
}
