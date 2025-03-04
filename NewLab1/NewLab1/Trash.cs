using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLab1
{
    public abstract class Trash
    {
        public string Name { get; set; }
        public int Mass { get; set; }
        public Trash(string name, int mass)
        {
            Name = name;
            Mass = mass;
        }
        public abstract string GetSpecialInfo();
    }
}
