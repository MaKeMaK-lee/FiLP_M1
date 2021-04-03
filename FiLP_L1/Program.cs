using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiLP_L1
{
    public class Edition
    {
        public string Publisher { get; set; }
        public int NumberEdition { get; set; }
        public int YearWhenEdited { get; set; }
        public int PageCount { get; set; }
        public int Price { get; set; }
    }
    public class Author
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int YearBurned { get; set; }
    }
    public class Book
    {
        public string Name { get; set; }
        public Author Author { get; set; }
        public List<Edition> List { get; set; }
        public int CountExam { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Author a1 = new Author() { Name = "Nikolos", Lastname = "Bulba", YearBurned = 1987 };
            Author a2 = new Author() { Name = "Lapelion", Lastname = "De Sagastiya", YearBurned = 1817 };
            Author a3 = new Author() { Name = "Vasya", Lastname = "Savochkin", YearBurned = 1958 };
            List<Book> Biblio = new List<Book>() {
                new Book() {Name = "Как копать картоху", Author = a1, CountExam = 100000, List = new List<Edition>(){
                    new Edition(){ Price = 1000, NumberEdition = 1, PageCount = 450, Publisher = "RyazanskieKnigi322", YearWhenEdited = 2004 },
                    new Edition(){ Price = 1200, NumberEdition = 2, PageCount = 500, Publisher = "MoskovskieKnigi322", YearWhenEdited = 2005 },
                    new Edition(){ Price = 1600, NumberEdition = 3, PageCount = 370, Publisher = "RosiiskieKnigi322", YearWhenEdited = 2011 }
                } },
                new Book() {Name = "Le Purle Pupurle", Author = a2, CountExam = 5000, List = new List<Edition>(){
                    new Edition(){ Price = 1000, NumberEdition = 1, PageCount = 450, Publisher = "La Pupunte", YearWhenEdited = 1851 },
                } },
                new Book() {Name = "Как взращивать огурчики", Author = a1, CountExam = 500000, List = new List<Edition>(){
                    new Edition(){ Price = 1300, NumberEdition = 1, PageCount = 497, Publisher = "MoskovskieKnigi", YearWhenEdited = 2007 },
                    new Edition(){ Price = 1400, NumberEdition = 2, PageCount = 561, Publisher = "RosiiskieKnigi3000", YearWhenEdited = 2012 },
                    new Edition(){ Price = 1800, NumberEdition = 3, PageCount = 390, Publisher = "WorldKisekies", YearWhenEdited = 2017 }
                } },
                new Book() {Name = "Как собирать репейник", Author = a1, CountExam = 999999, List = new List<Edition>(){
                    new Edition(){ Price = 1500, NumberEdition = 1, PageCount = 769, Publisher = "RosiiskieKnigi322", YearWhenEdited = 2014 },
                    new Edition(){ Price = 25000, NumberEdition = 2, PageCount = 355, Publisher = "WorldKisekies", YearWhenEdited = 2019 }
                } },
                new Book() {Name = "Бурый город", Author = a3, CountExam = 70000, List = new List<Edition>(){
                    new Edition(){ Price = 100, NumberEdition = 1, PageCount = 300, Publisher = "Зорька пушистая", YearWhenEdited = 1978 },
                    new Edition(){ Price = 500, NumberEdition = 2, PageCount = 399, Publisher = "Ели-ели", YearWhenEdited = 1996 },
                } },
                new Book() {Name = "Пепельный город", Author = a3, CountExam = 75000, List = new List<Edition>(){
                    new Edition(){ Price = 150, NumberEdition = 1, PageCount = 350, Publisher = "Зорька пушистая", YearWhenEdited = 1981 },
                    new Edition(){ Price = 600, NumberEdition = 2, PageCount = 389, Publisher = "Ели-ели", YearWhenEdited = 1996 },
                } }
            };


            do
            {
                Console.Clear();
                Console.WriteLine("Библиотека:");
                foreach (var b in Biblio)
                {
                    Console.WriteLine($"\t{b.Name} ({b.CountExam} экз.), {b.Author.Name} {b.Author.Lastname} {b.Author.YearBurned}г.");
                    foreach (var e in b.List)
                        Console.WriteLine($"Издание {e.NumberEdition}: {e.Price} руб, {e.PageCount} стр. {e.Publisher}, {e.YearWhenEdited} год.");
                    Console.WriteLine();
                }

                Console.WriteLine("Нажмите код операции:\n1.Найти автора, у которого книга имеет самый ранний год издания.\n2.Найти все книги, изданные более одного раза(проверка по номеру издания).\n3.Найти все книги, изданные в заданном издательстве за последние десять лет.\n4.Найти все книги заданного автора.\n5.Найти все книги, цена которых превышает заданную сумму.\n");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        {
                            Author a = new Author();
                            int year = int.MaxValue;
                            foreach (var b in Biblio)
                                foreach (var e in b.List)
                                    if (e.YearWhenEdited < year)
                                    {
                                        year = e.YearWhenEdited;
                                        a = b.Author;
                                    }
                            Console.WriteLine("Автор, у которого книга имеет самый ранний год издания: " + a.Name + " " + a.Lastname);
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            Console.WriteLine("Книги, изданные более одного раза:");
                            foreach (var b in Biblio)
                                foreach (var e in b.List)
                                    if (e.NumberEdition > 1)
                                    {
                                        Console.WriteLine(b.Name);
                                        break;
                                    }
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            Console.WriteLine("Нажмите код издателя:\n1: RyazanskieKnigi322\n2: MoskovskieKnigi322\n3: RosiiskieKnigi322\n4: WorldKisekies\n5: La Pupunte\n6: Зорька пушистая\n7: Ели-ели");
                            string pub = "";
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.D1:
                                    {
                                        pub = "RyazanskieKnigi322";
                                        break;
                                    }
                                case ConsoleKey.D2:
                                    {
                                        pub = "MoskovskieKnigi322";
                                        break;
                                    }
                                case ConsoleKey.D3:
                                    {
                                        pub = "RosiiskieKnigi322";
                                        break;
                                    }
                                case ConsoleKey.D4:
                                    {
                                        pub = "WorldKisekies";
                                        break;
                                    }
                                case ConsoleKey.D5:
                                    {
                                        pub = "La Pupunte";
                                        break;
                                    }
                                case ConsoleKey.D6:
                                    {
                                        pub = "Зорька пушистая";
                                        break;
                                    }
                                case ConsoleKey.D7:
                                    {
                                        pub = "Ели-ели";
                                        break;
                                    }
                            }
                            if (pub == "")
                            {
                                Console.WriteLine("Ничего не выполнено. Здесь следует нажать цифру 1-7 соответственно перечисленным пунктам.");
                                break;
                            }
                            Console.WriteLine($"\nКниги, изданные издательством {pub} за последние 10 лет (Сегодня {DateTime.Now.ToShortDateString()}):");
                            foreach (var b in Biblio)
                                foreach (var e in b.List)
                                    if (e.Publisher == pub)
                                        if (Math.Abs(e.YearWhenEdited - DateTime.Now.Year) <= 10)
                                        {
                                            Console.WriteLine(b.Name);
                                            break;
                                        }
                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            Console.WriteLine("Нажмите код Автора:\n1: Nikolos Bulba\n2: Lapelion De Sagastiya\n3: Vasya Savochkin");
                            Author auto = null;
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.D1:
                                    {
                                        auto = a1;
                                        break;
                                    }
                                case ConsoleKey.D2:
                                    {
                                        auto = a2;
                                        break;
                                    }
                                case ConsoleKey.D3:
                                    {
                                        auto = a3;
                                        break;
                                    }
                            }
                            if (auto == null)
                            {
                                Console.WriteLine("Ничего не выполнено. Здесь следует нажать цифру 1-3 соответственно перечисленным пунктам.");
                                break;
                            }
                            Console.WriteLine($"\nКниги автора {auto.Name} {auto.Lastname}:");
                            foreach (var b in Biblio)
                                if (b.Author == auto)
                                    Console.WriteLine(b.Name);
                            break;
                        }
                    case ConsoleKey.D5:
                        {
                            Console.WriteLine("Задайте цену:");
                            int pr = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine($"\nКниги с ценой > {pr}:");

                            bool w = true;
                            foreach (var b in Biblio)
                                foreach (var e in b.List)
                                    if (e.Price > pr)
                                    {
                                        Console.WriteLine(b.Name + ", издание " + e.NumberEdition);
                                        w = false;
                                    }
                            if (w)
                                Console.WriteLine("...не найдены.");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Ничего не выполнено. Здесь следует нажать цифру 1-5 соответственно перечисленным пунктам.");
                            break;
                        }
                }
                Console.WriteLine("\n\nДля завершения работы программы нажмите Esc, для продолжения любую клавишу.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);


        }
    }
}
/*
  {
            int _old = 1;
            int _new = 0;
            List<int> list = new List<int>() { 1, 213, -2, 35, -4, -34, 234, 3, 213, 7, 4, 1, 1, 1, -23, 3, 6, 7, 5, 3, -22 };

            do
            {
                Console.Clear();
                Console.WriteLine($"Текущие параметры: замена {_old} на {_new}. Список:");
                Console.Write("|");
                foreach (var a in list)
                    Console.Write($"{a,4}|");
                Console.WriteLine();

                Console.WriteLine("Если желаете провести замену с текущими параметрами, нажмите ПРОБЕЛ, для их измениня любую другую клавишу.");
                if (Console.ReadKey(true).Key != ConsoleKey.Spacebar)
                {

                    Console.WriteLine("Введите что заменять:");
                    _old = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите на что заменять:");
                    _new = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine($"\n||Замена {_old} на {_new}:");
                Console.WriteLine("Список до:");
                Console.Write("|");
                foreach (var a in list)
                    Console.Write($"{a,4}|");
                Console.WriteLine();

                for (int i = 0; i < list.Count; i++)
                    if (list[i] == _old)
                        list[i] = _new;

                Console.WriteLine("Список после:");
                Console.Write("|");
                foreach (var a in list)
                    Console.Write($"{a,4}|");
                Console.WriteLine();

                Console.WriteLine("\n\nДля завершения работы программы нажмите Esc, для продолжения любую клавишу.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);


        }
 * 
 * 
 * 
*/