namespace ExceptionFin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вывод исключений первого задания:");
            FirstTask();
            Console.WriteLine("Дальше идет второе задание \nВНИМАНИЕ! При любой ошибке ввода первое задание пропадет с экрана!");
            SecondTask();
        }
        static void PrintList(List<string> people, string message)
        {
            Console.WriteLine(message);
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
        static void FirstTask()
        {
            //Первое задание
            Exception[] excmass = new Exception[5] {new DivideByZeroException(),
                                                    new IndexOutOfRangeException(),
                                                    new OverflowException(),
                                                    new FormatException(),
                                                    new MyException("Слишком маленькое число!") };
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    switch (i)
                    {
                        case 0:
                            decimal a = 5;
                            decimal rez = a / 0;
                            break;
                        case 1:
                            Console.WriteLine(excmass[5]);
                            break;
                        case 2:
                            string c = "2147483680";
                            int b = int.Parse(c);
                            break;
                        case 3:
                            string d = "afafafaf";
                            int e = int.Parse(d);
                            break;
                        case 4:
                            int f = 15;
                            if (f < 18) throw excmass[i];
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Сработало исключение: " + ex.Message);
                }
            }
        }
        static void SecondTask()
        {
            //Второе задание
            var people = new List<string>(5);
            bool check = true;
            do
            {
                try
                {
                    if (people.Count == 5)
                    {
                        check = false;
                        PrintList(people, "Спасибо! Список фамилий:");
                    }
                    else
                    {
                        if (people.Count > 0)
                        {
                            PrintList(people, "Уже добавлены следующие люди:");
                        }
                        Console.WriteLine("Введите {0}-ю фамилию:", people.Count + 1);
                        string temp = Console.ReadLine();
                        if (temp.Trim() == "") throw new MyException("Вы не ввели ничего!");
                        int number;
                        bool parsecheck = int.TryParse(temp, out number);
                        if (parsecheck) throw new FormatException("Вы ввели число!");
                        foreach (var person in people)
                        {
                            if (person == temp) throw new MyException("Такой человек уже есть!");
                        }
                        Console.Clear();
                        people.Add(temp);
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
            while (check);
            check = true;
            do
            {
                try
                {
                    Console.WriteLine("Выберите тип сортировки: \n 1 - по возрастанию \n 2 - по убыванию");
                    string temp = Console.ReadLine();
                    int number;
                    bool parsecheck = int.TryParse(temp, out number);
                    if (!parsecheck) throw new FormatException("Вы ввели не число!");
                    if ((number == 1) | (number == 2))
                    {
                        check = false;
                        switch (number)
                        {
                            case 1:
                                var ascSortedPeople = people.OrderBy(p => p);
                                foreach (var person in ascSortedPeople)
                                {
                                    Console.WriteLine(person);
                                }
                                break;
                            case 2:
                                var descSortedPeople = people.OrderByDescending(p => p);
                                foreach (var person in descSortedPeople)
                                {
                                    Console.WriteLine(person);
                                }
                                break;
                        }
                    }
                    else
                    {
                        throw new MyException("Вы ввели не 1 или 2!");
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    PrintList(people, "Список фамилий:");
                }
            }
            while (check);
        }
    }
    class MyException : Exception
    {
        public MyException(string message)
            : base(message) { }
    }
}