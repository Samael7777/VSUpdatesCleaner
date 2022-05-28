namespace VSUpdatesCleaner
{
    internal class Component
    {
        /// <summary>
        /// Имя папки компонента
        /// </summary>
        public string FolderName { get => folderName; set => Parse(value); }
        /// <summary>
        /// Название компонента
        /// </summary>
        public string ComponentName { get; private set; } = "";
        /// <summary>
        /// Версия
        /// </summary>
        public Version ComponentVersion { get; private set; } = new Version();
        /// <summary>
        /// Размер компонента, байт
        /// </summary>
        public long ComponentSize { get; private set; }

        /// <summary>
        /// Аттрибуты
        /// </summary>
        public Dictionary<string, string> Attributes { get; private set; } = new Dictionary<string, string>();

        private string folderName = "";

        public Component(string folderName)
        {
            FolderName = folderName;
            ComponentSize = GetDirSize(folderName);
        }
        public static bool operator ==(Component c1, Component c2)
        {
            if ((c1.ComponentName != c2.ComponentName)
                || (c1.Attributes.Count != c2.Attributes.Count))
                return false;

            foreach (var attr in c1.Attributes)
            {
                if (!c2.Attributes.TryGetValue(attr.Key, out string? c2attrvalue))
                    return false;

                if (attr.Value != c2attrvalue)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool operator !=(Component c1, Component c2)
        {
            return !(c1 == c2);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
        //Получение данных о компоненте по имени папки
        private void Parse(string value)
        {
            const char attributesSeparator = ',';   //Разделитель атрибутов
            const char valuesSeparator = '=';       //Разделитель пары ключ - значение

            //Очистка от лишних пробелов
            folderName = value.Trim(' ').Split(@"\").Last();
            if (string.IsNullOrEmpty(folderName))
                return;

            //Получение имени компонента
            string[] parts = folderName.Split(attributesSeparator);
            ComponentName = parts[0];

            //Получение атрибутов
            if (parts.Length <= 1)
                return;

            for (int i = 1; i < parts.Length; i++)
            {
                string[] attribsPair = parts[i].Split(valuesSeparator);
                if (attribsPair[0] == "version")
                {
                    ComponentVersion.SetString(attribsPair[1]);
                }
                else
                {
                    Attributes.Add(attribsPair[0], attribsPair.Length > 1 ? attribsPair[1] : "");
                }
            }
        }

        //Посчитать размер папки
        private static long GetDirSize(string DirPath)
        {
            long size = 0;

            string[] files =
                Directory.GetFiles(DirPath, "*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (fileInfo.Exists)
                {
                    size += fileInfo.Length;
                }
            }
            return size;
        }
    }
}