using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLab1
{
    public class TrashSorter<T> where T : Trash //Это дженериковый класс, который может работать с любым типом мусора, унаследованным от Trash.
    {
        private List<T> trashList = new List<T>();

        public void AddTrash(T trash) //Этот метод добавляет мусор в список сортировщика.
        {
            trashList.Add(trash);
        }

        public void ShowTrash() //Метод выводит список мусора и его характеристики.
        {
            foreach (var trash in trashList)
            {
                Console.WriteLine($"Название: {trash.Name}, Масса: {trash.Mass}, {trash.GetSpecialInfo()}");
            }
        }
    }
}
