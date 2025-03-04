using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLab1.Trashes
{
    public class OrganicTrash : Trash
    {
        public double DamagePercent { get; set; }
        public OrganicTrash(double damagePercent, string name, int mass) : base(name, mass)
        {
            DamagePercent = damagePercent;
        }
        public override string GetSpecialInfo()
        {
            return $"{DamagePercent}% повреждений";
        }
    }
}
