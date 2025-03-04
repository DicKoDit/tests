using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLab1.Trashes
{
    public class MetalTrash : Trash
    {
        public string MetalType { get; set; }
        public MetalTrash(string metalType, string name, int mass) : base(name, mass)
        {
            MetalType = metalType;
        }
        public override string GetSpecialInfo()
        {
            return $"Металл: {MetalType}";
        }
    }
}
