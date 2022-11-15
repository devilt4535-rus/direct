using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Direct;

public class Direct
{
    public void CreateDirectory()
    {
        Console.WriteLine("Введите путь создания директории");
        Console.WriteLine(@"Формат указания пути - C:\Users\User\Desktop\name");
        string path = Console.ReadLine();
        DirectoryInfo dir = new DirectoryInfo(path);
        try
        {
            if (!dir.Exists)
            {
                dir.Create();
                Console.WriteLine("Дерикторий создан");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Такой директорий уже есть");
                Console.WriteLine();
            }
        }
        catch
        {
            Console.WriteLine();
            Console.WriteLine("Ошибка");
            Console.WriteLine();
        }
    }
    public void DeleteDirectory()
    {
        Console.WriteLine("Введите путь удаления директории");
        string path = Console.ReadLine();
        DirectoryInfo dir = new DirectoryInfo(path);
        try
        {
            if (dir.Exists)
            {
                Console.WriteLine("Вы точно хотите удалить директорий?");
                Console.WriteLine("1. Да");
                Console.WriteLine("2. Нет");
                string select = Console.ReadLine();
                bool parse = int.TryParse(select, out var selected);
                if (parse)
                {
                    for (int i = 2; ; i++)
                    {
                        Console.WriteLine("Вы точно хотите удалить директорий?");
                        Console.WriteLine("1. Да");
                        Console.WriteLine("2. Нет");
                        string select1 = Console.ReadLine();
                        bool parse1 = int.TryParse(select1, out var selected1);





                    }
                }

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Такого директория нет");
                Console.WriteLine();
            }
        }
        catch
        {
            Console.WriteLine();
            Console.WriteLine("Ошибка");
            Console.WriteLine();
        }

    }
    public void CheckFilesInDirectory()
    {
        Console.WriteLine("Введите путь для просмотра директории");
        string path = Console.ReadLine();
        DirectoryInfo dir = new DirectoryInfo(path);
        if (dir.Exists)
        {
            string[] dirs = Directory.GetFiles(path);
            if (dirs.Count() == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Директорий пуст");
                Console.WriteLine();
            }
            else
            {
                foreach (string info in dirs)
                {
                    Console.WriteLine();
                    Console.WriteLine(info);
                    Console.WriteLine();
                }
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Такого директория нет");
            Console.WriteLine();
        }
    }
    public void DeleteFilesInDirectory()
    {
        Console.WriteLine("Введите путь файла для его удаления");
        string path = Console.ReadLine();
        FileInfo file = new FileInfo($@"{path}.txt");
        if (file.Exists)
        {
            file.Delete();
            Console.WriteLine("Файл удалён");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Такого файла нет");
            Console.WriteLine();
        }
    }
    public void CreateFile()
    {
        Console.WriteLine();
        Console.WriteLine("Введите путь где вы хотите создать файл");
        Console.WriteLine(@"В формате C:\Users\User\Desktop");
        Console.WriteLine();
        string path = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Введите название файла");
        Console.WriteLine();
        string path1 = Console.ReadLine();
        FileInfo file = new FileInfo($@"{path}\{path1}.txt");
        try
        {
            using (file.Create())
            {
                Console.WriteLine();
                Console.WriteLine("Файл успешно создан ");
                Console.WriteLine();
                Console.WriteLine($@"Корневая папка файла - {path}\{path1}");
                Console.WriteLine();

            }
        }
        catch
        {
            Console.WriteLine();
            Console.WriteLine("Ошибка, введите путь в корректном формате");
            Console.WriteLine();
        }

    }

    public void WriteInFile()
    {
        Console.WriteLine();
        Console.WriteLine("Введите путь где находится файл");
        Console.WriteLine(@"В формате C:\Users\User\Desktop\YourFile");
        Console.WriteLine();
        string path = Console.ReadLine();
        FileInfo file = new FileInfo($@"{path}.txt");
        if (!file.Exists)
        {
            Console.WriteLine("Файла нет");
            return;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Введите что вы хотите записать в файл");
            Console.WriteLine();
            string text = Console.ReadLine();
            Console.WriteLine("Перезаписать файл?");
            Console.WriteLine("1. Да");
            Console.WriteLine("2. Нет");
            string select = Console.ReadLine();
            bool parse = int.TryParse(select, out var selected);
            if (parse)
            {
                if (selected == 1)
                {
                    using (StreamWriter path2 = new StreamWriter(file.FullName, false))
                    {
                        Console.WriteLine();
                        path2.Write(text);
                        Console.WriteLine();
                    }
                    return;
                }
                else if (selected == 2)
                {
                    using (StreamWriter path2 = new StreamWriter(file.FullName, true))
                    {
                        Console.WriteLine();
                        path2.Write(text);
                        Console.WriteLine();
                    }
                    return;
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Введите корректную команду");
                Console.WriteLine();
            }
        }
    }
    public void ReadFile()
    {
        try
        {
            Console.WriteLine();
            Console.WriteLine("Введите путь где находится файл");
            Console.WriteLine(@"В формате C:\Users\User\Desktop\YourFile");
            Console.WriteLine();
            string path = Console.ReadLine();
            using (StreamReader reader = new StreamReader($@"{path}.txt"))
            {

                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(@"////////////////////");
                    Console.WriteLine("Запись в файле");
                    Console.WriteLine(line);
                    Console.WriteLine(@"\\\\\\\\\\\\\\\\\\\\");

                    FileInfo file = new FileInfo($@"{path}.txt");
                    if (file.Exists)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Данные о файле");
                        Console.WriteLine($"Имя файла: {file.Name}");
                        Console.WriteLine($"Время создания: {file.CreationTime}");
                        Console.WriteLine($"Размер: {file.Length} байт");
                        Console.WriteLine();
                    }
                }
            }

        }
        catch
        {
            Console.WriteLine();
            Console.WriteLine("Ошибка, введите путь в корректном формате");
            Console.WriteLine();
        }
    }
}

