using System;

namespace rps2
{
    internal class FileFunction
    {
        public static string GetFilePath()
        {
            Console.WriteLine("Введите имя файла:");
            string filePath = @"C:\Users\Арина\Desktop\сем 4\rps2\" + Console.ReadLine();
            do
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Файл по указанному пути не найден. Пожалуйста, введите другой путь:");
                    filePath = @"C:\Users\Арина\Desktop\сем 4\rps2\" + Console.ReadLine();
                }
            } while (!File.Exists(filePath));

            return filePath;
        }

        public static void SaveListToFile(int[] list)
        {
            string filePath = FileFunction.GetFilePath();

            if (File.Exists(filePath))
            {
                Console.WriteLine("Файл по указанному пути уже существует. Хотите перезаписать его? (y/n)");
                string answer = Checks.rightChoice();

                if (answer.ToLower() == "y")
                {
                    using (StreamWriter writer = new StreamWriter(filePath, false))
                    {
                        // Сначала записываем размер массива
                        writer.WriteLine(list.Length);

                        // Затем записываем каждый элемент массива
                        foreach (int number in list)
                        {
                            writer.WriteLine(number);
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("Файл перезаписан.");
                }
                else
                {
                    Console.WriteLine("Операция отменена.");
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    // Сначала записываем размер массива
                    writer.WriteLine(list.Length);

                    // Затем записываем каждый элемент массива
                    foreach (int number in list)
                    {
                        writer.WriteLine(number);
                    }
                }
            }
        }

        public static (int[] array, bool errFlag) AddArrayFromFile(int[] array, string filePath, bool f)
        {
            if (f)
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    int size = int.Parse(reader.ReadLine());
                    for (int i = 0; i < size; i++)
                    {
                        array = array.Concat(new int[] { int.Parse(reader.ReadLine()) }).ToArray();
                    }
                }
                return (array, f);
            }
            else
            {
                Console.WriteLine("Добавлен пустой массив");
                return (array, f);
            }
        }
    }
}
