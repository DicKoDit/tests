using System.Collections.Generic;
using System.Xml.Linq;

namespace Lab1
{
    internal class Program
    {
        public static List<Trash> listOfAllTrash { get; set; } = new List<Trash>();
        static void Main(string[] args)
        {
            bool bo2 = false;
            bool bo = true;
            // Создаём 4 сортировщика для разных типов мусора
            TrashSorter<Type> trash_sorter1 = new TrashSorter<Type>();
            TrashSorter<Type> trash_sorter2 = new TrashSorter<Type>();
            TrashSorter<Type> trash_sorter3 = new TrashSorter<Type>();
            TrashSorter<Type> trash_sorter4 = new TrashSorter<Type>();
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Draw("----------Меню---------- \n\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1 - Добавить мусор.");
                Console.WriteLine("2 - Отфильтровать мусор.");
                Console.WriteLine("3 - Показать весь мусор.\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            bool isInputCorrect = false;
                            while (isInputCorrect == false)
                            {
                                string metalType = "0";
                                string damagepercent = "0";
                                int rndresult = 0;
                                bool recycleable = false;
                                string TypeOfCurse = "0";

                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Название мусора: ");
                                string name = Console.ReadLine();
                                if (IsInputEmpty(name))
                                {

                                }
                                else
                                {
                                    name = "Безымянный";

                                }
                                Console.Write("Масса: ");
                                var mass = Console.ReadLine();
                                if (int.TryParse(mass, out var Mass) == true)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Выберите тип мусора: \n");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("1 - Органический. \n");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("2 - Металлический. \n");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("3 - Пластиковый. \n");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("4 - Магический. \n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    string extrainput = Console.ReadLine();
                                    switch (extrainput)
                                    {
                                        case "1":
                                            {

                                                Console.Clear();
                                                Console.Write("Степень повреждения (в процентах): ");
                                                damagepercent = Console.ReadLine();
                                                if (double.TryParse(damagepercent, out double Damagepercent) == true)
                                                {
                                                    if (Convert.ToDouble(damagepercent) <= 100)
                                                    {
                                                        OrganicTrash trash = new OrganicTrash(Convert.ToDouble(damagepercent), name, Convert.ToInt32(mass));

                                                        TrashSorter<OrganicTrash>.AddTrash(trash, name, Convert.ToInt32(mass), Convert.ToDouble(damagepercent), recycleable, metalType, TypeOfCurse);
                                                        Console.Clear();
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.Write("Успешно!");
                                                        Thread.Sleep(1000);
                                                        break;
                                                    }
                                                    else 
                                                    {
                                                        Console.Clear();
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.Write("Введено некорректное значение! (Степень повреждения не может быть больше 100%)");
                                                        Thread.Sleep(2500);
                                                        break;

                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.ForegroundColor= ConsoleColor.Red;
                                                    Console.Write("Введено некорректное значение! (Вводите без знака %)");
                                                    Thread.Sleep(1000);
                                                    break;
                                                }
                                            }
                                        case "2":
                                            {
                                                Console.Clear();
                                                Console.Write("Тип металла: ");
                                                metalType = Console.ReadLine();
                                                MetalTrash trash = new MetalTrash(metalType, name, Convert.ToInt32(mass));

                                                TrashSorter<MetalTrash>.AddTrash(trash, name, Convert.ToInt32(mass), Convert.ToDouble(damagepercent), recycleable, metalType, TypeOfCurse);
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("Успешно!");
                                                Thread.Sleep(1000);
                                                break;
                                            }
                                        case "3":
                                            {
                                                Console.Clear();
                                                Random rnd = new Random();
                                                rndresult = rnd.Next(2);
                                                if (rndresult == 1)
                                                {
                                                    recycleable = true;
                                                }
                                                else recycleable = false;
                                                PlasticTrash trash = new PlasticTrash(recycleable, name, Convert.ToInt32(mass));

                                                TrashSorter<PlasticTrash>.AddTrash(trash, name, Convert.ToInt32(mass), Convert.ToDouble(damagepercent), recycleable, metalType, TypeOfCurse);
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("Успешно!");
                                                Thread.Sleep(1000);
                                                break;
                                            }
                                        case "4":
                                            {
                                                Console.Clear();
                                                Console.Write("Тип ");
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.Write("проклятья");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Write(": ");
                                                TypeOfCurse = Console.ReadLine();
                                                CursedTrash trash = new CursedTrash(TypeOfCurse, name, Convert.ToInt32(mass));

                                                TrashSorter<CursedTrash>.AddTrash(trash, name, Convert.ToInt32(mass), Convert.ToDouble(damagepercent), recycleable, metalType, TypeOfCurse);
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("Успешно!");
                                                Thread.Sleep(1000);
                                                break;
                                            }
                                        default:
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.Write("Введено некорректное значение!");
                                                Thread.Sleep(1000);
                                                break;
                                            }
                                    }
                                    isInputCorrect = true;
                                    break;
                                }
                                else { Console.Clear(); Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введено некорректное значение!"); Thread.Sleep(1000); };
                            }
                            break;
                        }
                    case "2":
                        {
                            bo2 = true;
                            List<Type> list_vr = new List<Type>();
                            for (int i = 0; i < listOfAllTrash.Count(); i++)
                            {
                                //Dictionary<string, int> list_vr = new Dictionary<string, int>();


                                list_vr.Add(listOfAllTrash[i].GetType());

                            }
                            var noDupes = list_vr.Distinct().ToList();
                            int vr = noDupes.Count;
                            if (vr == 4)
                            {
                                trash_sorter1.listOfTrashToExport = listOfAllTrash.ToList();
                                trash_sorter2.listOfTrashToExport = (trash_sorter1.Sorter()).ToList();
                                trash_sorter3.listOfTrashToExport = (trash_sorter2.Sorter()).ToList();
                                trash_sorter4.listOfTrashToExport = (trash_sorter3.Sorter()).ToList();
                                trash_sorter4.Sorter();
                            }
                            if (vr == 3)
                            {
                                trash_sorter1.listOfTrashToExport = listOfAllTrash.ToList();
                                trash_sorter2.listOfTrashToExport = (trash_sorter1.Sorter()).ToList();
                                trash_sorter3.listOfTrashToExport = (trash_sorter2.Sorter()).ToList();
                                trash_sorter3.Sorter();
                            }
                            if (vr == 2)
                            {
                                trash_sorter1.listOfTrashToExport = listOfAllTrash.ToList();
                                trash_sorter2.listOfTrashToExport = (trash_sorter1.Sorter()).ToList();
                                trash_sorter2.Sorter();
                            }
                            if (vr == 1)
                            {
                                trash_sorter1.listOfTrashToExport = listOfAllTrash.ToList();
                                trash_sorter1.Sorter();
                            }
                            if (vr == 0)
                            {

                            }
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Успешно!");
                            Thread.Sleep(1000);
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            Console.WriteLine("Список всего мусора: \n");
                            bool bo3 = true;
                            bool bo4 = true;
                            List<Trash> heap = new List<Trash>();
                            if (bo2)
                            {
                                for (int i = 0; i < trash_sorter1.listOfTrash.Count; i++)
                                {
                                    if (trash_sorter1.listOfTrash[i] is OrganicTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                                        Console.Write($"{trash_sorter1.listOfTrash[i].Name}{Spaces(trash_sorter1.listOfTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {trash_sorter1.listOfTrash[i].Mass}");
                                        Console.WriteLine($"Степень повреждения: {trash_sorter1.listOfTrash[i].GetSpecialInfo()}%\n\n");
                                        heap.Add(trash_sorter1.listOfTrash[i]);
                                    }
                                    if (trash_sorter1.listOfTrash[i] is MetalTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkGray;
                                        Console.Write($"{trash_sorter1.listOfTrash[i].Name}{Spaces(trash_sorter1.listOfTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {trash_sorter1.listOfTrash[i].Mass}");
                                        Console.WriteLine($"Тип металла: {trash_sorter1.listOfTrash[i].GetSpecialInfo()}\n\n");
                                        heap.Add(trash_sorter1.listOfTrash[i]);
                                    }
                                    if (trash_sorter1.listOfTrash[i] is PlasticTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                                        Console.Write($"{trash_sorter1.listOfTrash[i].Name}{Spaces(trash_sorter1.listOfTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {trash_sorter1.listOfTrash[i].Mass}");
                                        Console.WriteLine($"Перерабатываемость: {trash_sorter1.listOfTrash[i].GetSpecialInfo()}\n\n");
                                        heap.Add(trash_sorter1.listOfTrash[i]);
                                    }
                                    if (trash_sorter1.listOfTrash[i] is CursedTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkRed;
                                        Console.Write($"{trash_sorter1.listOfTrash[i].Name}{Spaces(trash_sorter1.listOfTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {trash_sorter1.listOfTrash[i].Mass}");
                                        Console.WriteLine($"Тип проклятья: {trash_sorter1.listOfTrash[i].GetSpecialInfo()}\n\n");
                                        heap.Add(trash_sorter1.listOfTrash[i]);
                                    }
                                }
                                for (int i = 0; i < trash_sorter2.listOfTrash.Count; i++)
                                {
                                    if (trash_sorter2.listOfTrash[i] is OrganicTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                                        Console.Write($"{trash_sorter2.listOfTrash[i].Name}{Spaces(trash_sorter2.listOfTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {trash_sorter2.listOfTrash[i].Mass}");
                                        Console.WriteLine($"Степень повреждения: {trash_sorter2.listOfTrash[i].GetSpecialInfo()}%\n\n");
                                        heap.Add(trash_sorter2.listOfTrash[i]);
                                    }
                                    if (trash_sorter2.listOfTrash[i] is MetalTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkGray;
                                        Console.Write($"{trash_sorter2.listOfTrash[i].Name}{Spaces(trash_sorter2.listOfTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {trash_sorter2.listOfTrash[i].Mass}");
                                        Console.WriteLine($"Тип металла: {trash_sorter2.listOfTrash[i].GetSpecialInfo()}\n\n");
                                        heap.Add(trash_sorter2.listOfTrash[i]);
                                    }
                                    if (trash_sorter2.listOfTrash[i] is PlasticTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                                        Console.Write($"{trash_sorter2.listOfTrash[i].Name}{Spaces(trash_sorter2.listOfTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {trash_sorter2.listOfTrash[i].Mass}");
                                        Console.WriteLine($"Перерабатываемость: {trash_sorter2.listOfTrash[i].GetSpecialInfo()}\n\n");
                                        heap.Add(trash_sorter2.listOfTrash[i]);
                                    }
                                    if (trash_sorter2.listOfTrash[i] is CursedTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkRed;
                                        Console.Write($"{trash_sorter2.listOfTrash[i].Name}{Spaces(trash_sorter2.listOfTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {trash_sorter2.listOfTrash[i].Mass}");
                                        Console.WriteLine($"Тип проклятья: {trash_sorter2.listOfTrash[i].GetSpecialInfo()}\n\n");
                                        heap.Add(trash_sorter2.listOfTrash[i]);
                                    }
                                }
                                for (int i = 0; i < trash_sorter3.listOfTrash.Count; i++)
                                {
                                    if (trash_sorter3.listOfTrash[i] is OrganicTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                                        Console.Write($"{trash_sorter3.listOfTrash[i].Name}{Spaces(trash_sorter3.listOfTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {trash_sorter3.listOfTrash[i].Mass}");
                                        Console.WriteLine($"Степень повреждения: {trash_sorter3.listOfTrash[i].GetSpecialInfo()}%\n\n");
                                        heap.Add(trash_sorter3.listOfTrash[i]);
                                    }
                                    if (trash_sorter3.listOfTrash[i] is MetalTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkGray;
                                        Console.Write($"{trash_sorter3.listOfTrash[i].Name}{Spaces(trash_sorter3.listOfTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {trash_sorter3.listOfTrash[i].Mass}");
                                        Console.WriteLine($"Тип металла: {trash_sorter3.listOfTrash[i].GetSpecialInfo()}\n\n");
                                        heap.Add(trash_sorter3.listOfTrash[i]);
                                    }
                                    if (trash_sorter3.listOfTrash[i] is PlasticTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                                        Console.Write($"{trash_sorter3.listOfTrash[i].Name}{Spaces(trash_sorter3.listOfTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {trash_sorter3.listOfTrash[i].Mass}");
                                        Console.WriteLine($"Перерабатываемость: {trash_sorter3.listOfTrash[i].GetSpecialInfo()}\n\n");
                                        heap.Add(trash_sorter3.listOfTrash[i]);
                                    }
                                    if (trash_sorter3.listOfTrash[i] is CursedTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkRed;
                                        Console.Write($"{trash_sorter3.listOfTrash[i].Name}{Spaces(trash_sorter3.listOfTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {trash_sorter3.listOfTrash[i].Mass}");
                                        Console.WriteLine($"Тип проклятья: {trash_sorter3.listOfTrash[i].GetSpecialInfo()}\n\n");
                                        heap.Add(trash_sorter3.listOfTrash[i]);
                                    }
                                }
                                for (int i = 0; i < trash_sorter4.listOfTrash.Count; i++)
                                {
                                    if (trash_sorter4.listOfTrash[i] is OrganicTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                                        Console.Write($"{trash_sorter4.listOfTrash[i].Name}{Spaces(trash_sorter4.listOfTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {trash_sorter4.listOfTrash[i].Mass}");
                                        Console.WriteLine($"Степень повреждения: {trash_sorter4.listOfTrash[i].GetSpecialInfo()}%\n\n");
                                        heap.Add(trash_sorter4.listOfTrash[i]);
                                    }
                                    if (trash_sorter4.listOfTrash[i] is MetalTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkGray;
                                        Console.Write($"{trash_sorter4.listOfTrash[i].Name}{Spaces(trash_sorter4.listOfTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {trash_sorter4.listOfTrash[i].Mass}");
                                        Console.WriteLine($"Тип металла: {trash_sorter4.listOfTrash[i].GetSpecialInfo()}\n\n");
                                        heap.Add(trash_sorter4.listOfTrash[i]);
                                    }
                                    if (trash_sorter4.listOfTrash[i] is PlasticTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                                        Console.Write($"{trash_sorter4.listOfTrash[i].Name}{Spaces(trash_sorter4.listOfTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {trash_sorter4.listOfTrash[i].Mass}");
                                        Console.WriteLine($"Перерабатываемость: {trash_sorter4.listOfTrash[i].GetSpecialInfo()}\n\n");
                                        heap.Add(trash_sorter4.listOfTrash[i]);
                                    }
                                    if (trash_sorter4.listOfTrash[i] is CursedTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkRed;
                                        Console.Write($"{trash_sorter4.listOfTrash[i].Name}{Spaces(trash_sorter4.listOfTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {trash_sorter4.listOfTrash[i].Mass}");
                                        Console.WriteLine($"Тип проклятья: {trash_sorter4.listOfTrash[i].GetSpecialInfo()}\n\n");
                                        heap.Add(trash_sorter4.listOfTrash[i]);
                                    }
                                }
                                for (int i = 0; i < listOfAllTrash.Count; i++)
                                {
                                    bo = true;
                                    for (int j = 0; j < heap.Count; j++)
                                    {
                                        if (listOfAllTrash[i] == heap[j])
                                        {
                                            bo = false;
                                            break;
                                        }
                                    }
                                    if (bo)
                                    {
                                        if (bo4)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\n\nНеотфильтрованный мусор: \n");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            bo4 = false;
                                        }
                                        if (listOfAllTrash[i] is OrganicTrash)
                                        {
                                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                                            Console.Write($"{listOfAllTrash[i].Name}{Spaces(listOfAllTrash[i].Name)}");
                                            Console.ResetColor();
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("│");
                                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                            Console.WriteLine($"Масса: {listOfAllTrash[i].Mass}");
                                            Console.WriteLine($"Степень повреждения: {listOfAllTrash[i].GetSpecialInfo()}%\n\n");
                                        }
                                        if (listOfAllTrash[i] is MetalTrash)
                                        {
                                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                            Console.BackgroundColor = ConsoleColor.DarkGray;
                                            Console.Write($"{listOfAllTrash[i].Name}{Spaces(listOfAllTrash[i].Name)}");
                                            Console.ResetColor();
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("│");
                                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                            Console.WriteLine($"Масса: {listOfAllTrash[i].Mass}");
                                            Console.WriteLine($"Тип металла: {listOfAllTrash[i].GetSpecialInfo()}\n\n");
                                        }
                                        if (listOfAllTrash[i] is PlasticTrash)
                                        {
                                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                                            Console.Write($"{listOfAllTrash[i].Name}{Spaces(listOfAllTrash[i].Name)}");
                                            Console.ResetColor();
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("│");
                                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                            Console.WriteLine($"Масса: {listOfAllTrash[i].Mass}");
                                            Console.WriteLine($"Перерабатываемость: {listOfAllTrash[i].GetSpecialInfo()}\n\n");
                                        }
                                        if (listOfAllTrash[i] is CursedTrash)
                                        {
                                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                            Console.BackgroundColor = ConsoleColor.DarkRed;
                                            Console.Write($"{listOfAllTrash[i].Name}{Spaces(listOfAllTrash[i].Name)}");
                                            Console.ResetColor();
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("│");
                                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                            Console.WriteLine($"Масса: {listOfAllTrash[i].Mass}");
                                            Console.WriteLine($"Тип проклятья: {listOfAllTrash[i].GetSpecialInfo()}\n\n");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < listOfAllTrash.Count; i++)
                                {

                                    if (listOfAllTrash[i] is OrganicTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                                        Console.Write($"{listOfAllTrash[i].Name}{Spaces(listOfAllTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {listOfAllTrash[i].Mass}");
                                        Console.WriteLine($"Степень повреждения: {listOfAllTrash[i].GetSpecialInfo()}%\n\n");
                                    }
                                    if (listOfAllTrash[i] is MetalTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkGray;
                                        Console.Write($"{listOfAllTrash[i].Name}{Spaces(listOfAllTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {listOfAllTrash[i].Mass}");
                                        Console.WriteLine($"Тип металла: {listOfAllTrash[i].GetSpecialInfo()}\n\n");
                                    }
                                    if (listOfAllTrash[i] is PlasticTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                                        Console.Write($"{listOfAllTrash[i].Name}{Spaces(listOfAllTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {listOfAllTrash[i].Mass}");
                                        Console.WriteLine($"Перерабатываемость: {listOfAllTrash[i].GetSpecialInfo()}\n\n");
                                    }
                                    if (listOfAllTrash[i] is CursedTrash)
                                    {
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.BackgroundColor = ConsoleColor.DarkRed;
                                        Console.Write($"{listOfAllTrash[i].Name}{Spaces(listOfAllTrash[i].Name)}");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("│");
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine($"Масса: {listOfAllTrash[i].Mass}");
                                        Console.WriteLine($"Тип проклятья: {listOfAllTrash[i].GetSpecialInfo()}\n\n");
                                    }
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("\n\nНажмите любую клавишу, чтобы продолжить...");
                            Console.ReadKey();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Введено некорректное значение!");
                            Thread.Sleep(1000);
                            break;
                        }
                }
            }
        }
        static string Spaces (string str)
        {
            int spacesCount = 23 - str.Length;
            string spaces = "";
            for (int i = 0; i < spacesCount; i++)
            {
                spaces += " ";
            }
            return spaces;
        }

        static void Draw (string str)
        {
            for (int i = 0; i < str.Length;i++)
            {
                Console.Write(str[i]);
                Thread.Sleep(10);
            }
        }

        static bool IsInputEmpty(string str) 
        {
            string Alphabet = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMйцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ1234567890";
            for (int i = 0; i < str.Length; i++)
            {
                if (Alphabet.Contains(str[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}