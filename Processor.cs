namespace VSUpdatesCleaner
{
    internal static class Processor
    {
        private static ComponentsList componentsList = new(); //Список всех компонентов
        /// <summary>
        /// Исходная папка
        /// </summary>
        public static DirectoryInfo SourceDirectory { get; set; }

        /// <summary>
        /// Сканирование папки компонентов
        /// </summary>
        public static void Scan()
        {
            ScanComponents();
        }
        /// <summary>
        /// Удаление дубликатов
        /// </summary>
        public static void Delete()
        {
            ScanComponents();

            if (componentsList.Outdated == 0)
            {
                Console.WriteLine("Устаревших компонентов не обнаружено");
                return;
            }

            Console.Write("Удаление дубликатов....");
            int deleted = 0;
            foreach (var i in componentsList.ItemsList)
            {
                if (i.Count > 1)
                {
                    foreach (var j in i.GetDuplicates())
                    {
                        string src = SourceDirectory.FullName + @"\" + j.FolderName;
                        Directory.Delete(src, true);
                        deleted++;
                    }
                }
            }
            Console.WriteLine($"Удаление успешно завершено. \r\n" +
                $"Удалено {deleted} дубликатов");
        }

        /// <summary>
        /// Перенос дубликатов
        /// </summary>
        /// <param name="DestinationDir">Папка назначения</param>
        public static void Move(DirectoryInfo DestinationDir)
        {
            ScanComponents();

            if (componentsList.Outdated == 0)
            {
                Console.WriteLine("Устаревших компонентов не обнаружено");
                return;
            }

            Console.Write("Перенос дубликатов....");
            Directory.CreateDirectory(DestinationDir.FullName);
            int moved = 0;
            foreach (var i in componentsList.ItemsList)
            {
                if (i.Count > 1)
                {
                    foreach (var j in i.GetDuplicates())
                    {
                        string src = SourceDirectory.FullName + @"\" + j.FolderName;
                        string dst = DestinationDir.FullName + @"\" + j.FolderName;
                        Directory.Move(src, dst);
                        moved++;
                    }
                }
            }
            Console.WriteLine($"Перемещение успешно завершено.\r\n" +
                $"Перемещено {moved} дубликатов");
        }

        private static void ScanComponents()
        {
            if (SourceDirectory == null)
            {
                throw new ArgumentNullException("Не указана исходная папка");
            }
            if (!SourceDirectory.Exists)
            {
                throw new ArgumentException("Исходная папка не существует");
            }

            //Получение списка папок
            Console.Write("Получение списка папок... ");
            string[] Directories = Directory.GetDirectories(SourceDirectory.FullName);
            Console.WriteLine($"найдено {Directories.Length} папок.\r\n");

            //Создание списка компонентов
            Console.WriteLine("Сканирование компонентов... ");
            for (int i = 0; i < Directories.Length; i++)
            {
                componentsList.AddComponent(new Component(Directories[i]));
            }
            Console.WriteLine($"Обнаружено компонентов: {componentsList.Count}");
            Console.WriteLine($"Всего занято компонентами: {(componentsList.TotalSize / 1048576f):### ###.#} Мб");
            Console.WriteLine($"Обнаружено дубликатов: {componentsList.Outdated}");
            Console.WriteLine($"Всего занято дубликатам {(componentsList.TotalOutdatedSize / 1048576f):### ###.#} Мб\r\n");
        }
    }
}
