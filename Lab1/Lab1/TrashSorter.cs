using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    //Дженериковый класс, который сортирует мусор типа Т — Trash — Мусор
    public class TrashSorter<T>
    {
        public List<Trash> listOfTrash { get; set; } = new List<Trash>(); // Список для хранения мусора этого типа
        public List<Trash> listOfTrashToExport { get; set; } = new List<Trash>(); // Следующий сортировщик в цепочке (если мусор не подходит текущему)

        // Метод для добавления мусора в текущий сортировщик
        public static void AddTrash(T type, string name, int mass, double damagepercent, bool recycleable, string metaltype, string TypeOfCurse)
        {
            if (type is T == true) //Проверка на Органику
            {
                OrganicTrash trash = new OrganicTrash(damagepercent, name, mass);
                Lab1.Program.listOfAllTrash.Add(trash); // Добавляем мусор в список
            }
            if (type is T == true) //Проверка на Металл
            {
                MetalTrash trash = new MetalTrash(metaltype, name, mass);
                Lab1.Program.listOfAllTrash.Add(trash);// Добавляем мусор в список
            }
            if (type is T == true) //Проверка на Пластик
            {
                PlasticTrash trash = new PlasticTrash(recycleable, name, mass);
                Lab1.Program.listOfAllTrash.Add(trash);// Добавляем мусор в список
            }
            if (type is T == true) //Проверка на Злобное колдунство
            {
                CursedTrash trash = new CursedTrash(TypeOfCurse, name, mass);
                Lab1.Program.listOfAllTrash.Add(trash);// Добавляем мусор в список
            }
        }
        public List<Trash> Sorter()
        {
            listOfTrash.Clear();
            Type vr = listOfTrashToExport[0].GetType();
            for (int i = 0; i < listOfTrashToExport.Count; i++) // Проходимся по всему мусору в этом сортировщике
            {
                if (listOfTrashToExport[i].GetType() == vr)
                {
                    listOfTrash.Add(listOfTrashToExport[i]);
                    listOfTrashToExport.RemoveAt(i);
                    i--;
                }
            }
            return listOfTrashToExport; // Вызываем метод, который выводит информацию об этом мусоре
        }
    }
}