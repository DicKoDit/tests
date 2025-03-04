using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLab1.Trashes
{
    public class PlasticTrash : Trash
    {
        public bool Recyclable { get; set; }
        public PlasticTrash(bool recyclable, string name, int mass) : base(name, mass)
        {
            Recyclable = recyclable;
        }
        public override string GetSpecialInfo()
        {
            return Recyclable ? "Перерабатываемый" : "Не перерабатываемый"; // Тернарный оператор. Сокращает if-else
        }
    }
}
