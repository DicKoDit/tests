using NewLab1.Trashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLab1
{
    class Program
    {
        static void Main()
        {
            TrashSorter<OrganicTrash> organicSorter = new TrashSorter<OrganicTrash>();
            TrashSorter<MetalTrash> metalSorter = new TrashSorter<MetalTrash>();
            TrashSorter<PlasticTrash> plasticSorter = new TrashSorter<PlasticTrash>();
            TrashSorter<CursedTrash> cursedSorter = new TrashSorter<CursedTrash>();

            //НЕ ЗАБУДЬ ДОБАВИТЬ СЮДА МУСОР!!!!!!
            organicSorter.AddTrash(new OrganicTrash(80, "Гнилое яблоко", 2));
            organicSorter.AddTrash(new OrganicTrash(17, "Кусок дерева", 10));
            organicSorter.AddTrash(new OrganicTrash(31, "Сумка Гуссиная лапка", 1));

            metalSorter.AddTrash(new MetalTrash("Железо", "Старый болт", 1));
            metalSorter.AddTrash(new MetalTrash("Алюминий", "Всего одна ложечка мороженного))))", 5));

            plasticSorter.AddTrash(new PlasticTrash(true, "Пластиковая бутылка", 3));
            plasticSorter.AddTrash(new PlasticTrash(false, "Кусок забора из поликарбоната", 11));
            plasticSorter.AddTrash(new PlasticTrash(false, "Казан из биопластика", 1));

            cursedSorter.AddTrash(new CursedTrash("+25 к разочарованию в себе", "картина Cтарый человек", 1));


            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n--- Органический мусор ---");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            organicSorter.ShowTrash();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n--- Металлический мусор ---");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            metalSorter.ShowTrash();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n--- Пластиковый мусор ---");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            plasticSorter.ShowTrash();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n--- Проклятый мусор ---");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            cursedSorter.ShowTrash();

            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Вся масса объектов указанна в киллограммах. Для выхода из программы, нажмите на любую клавишу....");


            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Thread.Sleep(1500);
            Console.WriteLine("\n");
            Console.Write("Я не шучу, любую...");

            Console.ReadKey();
        }
    }
}
