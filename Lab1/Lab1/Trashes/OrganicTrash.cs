using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab1
{
    public class OrganicTrash : Trash
    {
        public double DamagePercent { get; set; }
        public OrganicTrash(double damagepercent, string name, int mass) : base(name, mass)
        {
            DamagePercent = damagepercent;
        }
        public override string GetSpecialInfo()
        {
            return Convert.ToString(DamagePercent);
        }
    }
}
