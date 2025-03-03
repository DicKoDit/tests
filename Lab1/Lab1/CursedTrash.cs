using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class CursedTrash : Trash
    {
        public string TypeOfCurse { get; set; }
        public CursedTrash(string TypeOfCurse, string name, int mass) : base(name, mass)
        {
            this.TypeOfCurse = TypeOfCurse;
        }
        public override string GetSpecialInfo()
        {
            return TypeOfCurse;
        }
    }
}
