using Direct;
internal class Program
{
    private static void Main(string[] args)
    {
        Directo direct = new Direct();
        void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Menu");
            Console.WriteLine();
            Console.WriteLine("1. Создать директорию");
            Console.WriteLine("2. Удалить директорию");
            Console.WriteLine("3. Проверить наличие файлов в директории");
            Console.WriteLine("4. Удалить файл из директории");
            Console.WriteLine("5. Создать текстовый файл");
            Console.WriteLine("6. Прочитать информацию c файла");
            Console.WriteLine("7. Записать информацию в файл");
        }
        void GetMenu()
        {
            string select = Console.ReadLine();
            bool parse = int.TryParse(select, out int selected);
            if (parse)
            {
                switch (selected)
                {
                    case 1:
                        direct.CreateDirectory();
                        break;
                    case 2:
                        direct.DeleteDirectory();
                        break;
                    case 3:
                        direct.CheckFilesInDirectory();
                        break;
                    case 4:
                        direct.DeleteFilesInDirectory();
                        break;
                    case 5:
                        direct.CreateFile();
                        break;
                    case 6:
                        direct.ReadFile();
                        break;
                    case 7:
                        direct.WriteInFile();
                        break;
                }
            }
        }
        while (true)
        {
            Menu();
            GetMenu();
        }
    }
}