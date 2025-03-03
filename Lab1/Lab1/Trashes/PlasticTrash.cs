using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class PlasticTrash : Trash
    {
        public bool RecycleAble {  get; set; }
        public PlasticTrash (bool  recycleable, string name, int mass) : base (name, mass)
        {
            RecycleAble = recycleable;
        }
        public override string GetSpecialInfo()
        {
            if (RecycleAble == true)
            {
                return "Да";
            }
            else return "Нет";
        }
    }
}
