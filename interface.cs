using System;

namespace rps2
{
    class Interface
    {
        public static void GiveWelcomeMessage()
        {
            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine("Вариант №3 работы №2 был выполнен студенткой группы 423 Барановой Ариной.");
            Console.WriteLine("Задание: Отсортировать массив так, чтобы все чётные элементы были слева, а нечётные справа.");
        }

        enum item1 
        {
            manual = 1,
            file,
            exit
        }

        enum item2
        {
            saveArray = 1,
            saveSortArray,
            back
        }

        public static void GiveMainMenu() 
        {
            Console.WriteLine("_______________________");
            Console.WriteLine("1 - ручной ввод и сортировка");
            Console.WriteLine("2 - добавление из файла и сортировка");
            Console.WriteLine("3 - завершить программу");
            Console.WriteLine("_______________________");
        }

        public static void GiveSaveMenu()
        {
            Console.WriteLine("_______________________");
            Console.WriteLine("1 - сохранить исходный массив");
            Console.WriteLine("2 - сохранить отсортированный массив");
            Console.WriteLine("3 - вернуться в главное меню");
            Console.WriteLine("_______________________");
        }

        public static void Instuctions()
        {
            Console.WriteLine("Введите размер массива");
        }

        public static Array AddArray(int size, int[] array)
        {
            /*Ввод с клавиатуры.*/
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Элемент {0}", i);
                //array[i] = Convert.ToInt32(Console.ReadLine());
                array[i] = Checks.checkInt();
            }
            return array;
        }

        public static void SeeArray(int size, int[] array)
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("{0} ", array[i]);
            }
        }

        public static Array Save(int[] array, int[] SortArray)
        {
            while (true)
            {
                int size = array.Length;
                GiveSaveMenu();
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 3)
                {
                    item2 selection = (item2)choice;

                    switch (selection)
                    {
                        case item2.saveArray:

                            FileFunction.SaveListToFile(array);

                            break;

                        case item2.saveSortArray:

                            FileFunction.SaveListToFile(SortArray);

                            break;

                        case item2.back:

                            mainMenu();

                            break;
                    }
                }
                else
                    Console.WriteLine("Такого пункта нет в меню");
            }
        }

        public static Array mainMenu()
        {
            while (true)
            {
                GiveMainMenu();
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 3)
                {
                    item1 selection = (item1)choice;
                    int size = 0;
                    int[] array = new int[size];
                    int[] SortArray = new int[size];

                    switch (selection)
                    {
                        case item1.manual:
                            Instuctions();
                            bool r = true;
                            do
                            {
                                if (int.TryParse(Console.ReadLine(), out size) && size >= 1)
                                {
                                    Array.Resize(ref array, size);
                                    Array.Resize(ref SortArray, size);
                                    
                                    AddArray(size, array);

                                    Console.WriteLine("___________________");
                                    SeeArray(size, array);
                                    Console.WriteLine("___________________");

                                    Sort.SortEvenOdd2(array, SortArray);
                                    SeeArray(size, SortArray);

                                    Save(array, SortArray);
                                    r = true;
                                }
                                else
                                {
                                    Console.WriteLine("щшибка ввода. Попробуйте ещё раз.");
                                    r = false;
                                }
                                    
                            } while (!r);

                            break;

                        case item1.file:

                            string path = FileFunction.GetFilePath();

                            (array, bool errFlag) =  FileFunction.AddArrayFromFile(array, path, Checks.IsValidFileForAddingArray(path));
                            if (errFlag)
                            {
                                size = array.Count();
                                Array.Resize(ref SortArray, size);

                                Sort.SortEvenOdd2(array, SortArray);
                                SeeArray(size, array);
                                Console.WriteLine("___________________");
                                SeeArray(size, SortArray);
                                Save(array, SortArray);
                            }

                        break;

                        case item1.exit:
                            Environment.Exit(0);

                        break;
                    }
                }
                else
                    Console.WriteLine("Такого пункта нет в меню");
            }
        }
    }
}