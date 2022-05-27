namespace VSUpdatesCleaner
{
    internal class ComponentsList
    {
        /// <summary>
        /// Общее число уникальных компонентов
        /// </summary>
        public int Count { get; private set; } = 0;
        /// <summary>
        /// Общее число устаревших компонентов
        /// </summary>
        public int Outdated { get; private set; } = 0;
        /// <summary>
        /// Всего занято места, байт
        /// </summary>
        public long TotalSize { get; private set; } = 0;
        /// <summary>
        /// Всего занято дубликатами, байт
        /// </summary>
        public long TotalOutdatedSize { get; private set; } = 0;

        /// <summary>
        /// Список уникальных компонентов
        /// </summary>
        public List<ComponentsListItem> ItemsList { get; private set; } = new();
        /// <summary>
        /// Добавить компонент
        /// </summary>
        /// <param name="item">Компонент</param>
        public void AddComponent(Component item)
        {
            //Добавляем только папки компонентов
            if (item.ComponentVersion.ToString() != "")
            {
                //Если такой компонент уже добавлен - то создаем дубликат
                if (ItemsList.Exists((x) => x.Main == item))
                {
                    ItemsList.Find((x) => x.Main == item)?.AddVersion(item);
                    Outdated++;
                    TotalOutdatedSize += item.ComponentSize;
                }
                //Добавляем новый компонент
                else
                {
                    ItemsList.Add(new ComponentsListItem(item));
                    Count++;
                }
                TotalSize += item.ComponentSize;
            }
        }
    }

    internal class ComponentsListItem
    {
        /// <summary>
        /// Количество версий компонентов
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Название компонента
        /// </summary>
        public string Name { get; private set; } = "";
        /// <summary>
        /// Основная версия компонента
        /// </summary>
        public Component Main { get; private set; }
        /// <summary>
        /// Суммарный размер устаревших версий
        /// </summary>
        public long OutdatedSize { get; private set; } = 0;

        private List<Component> items = new();

        public ComponentsListItem(Component item)
        {
            Name = item.ComponentName;
            Main = item;
            items.Add(item);
            Count = 1;
        }
        /// <summary>
        /// Добавить версию компонента
        /// </summary>
        /// <param name="item">Компонент</param>
        public void AddVersion(Component item)
        {
            if (items[0] == item)
            {
                items.Add(item);
                if (item.ComponentVersion > Main.ComponentVersion)
                    Main = item;
                Count++;
                OutdatedSize += item.ComponentSize;
            }
        }
        /// <summary>
        /// Список устаревших версий компонентов
        /// </summary>
        /// <returns></returns>
        public List<Component> GetDuplicates()
        {
            List<Component> result = new();
            foreach (var item in items)
            {
                if (item.ComponentVersion != Main.ComponentVersion)
                    result.Add(item);
            }
            return result;
        }
    }
}
