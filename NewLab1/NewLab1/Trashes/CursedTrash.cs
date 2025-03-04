using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLab1.Trashes
{
    public class CursedTrash : Trash
    {
        public string CurseType { get; set; }
        public CursedTrash(string curseType, string name, int mass) : base(name, mass)
        {
            CurseType = curseType;
        }
        public override string GetSpecialInfo()
        {
            return $"Проклятье: {CurseType}";
        }
    }
}
