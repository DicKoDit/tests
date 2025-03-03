using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class MetalTrash : Trash
    {
        public string MetalType {  get; set; }
        public MetalTrash(string metaltype, string name, int mass) : base(name, mass)
        {
            MetalType = metaltype;
        }
        public override string GetSpecialInfo()
        {
            return MetalType;
        }
    }
}
