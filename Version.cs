namespace VSUpdatesCleaner
{
    internal class Version
    {
        private string versionString;

        public Version()
        {
            versionString = "";
        }
        public Version(string versionString)
        {
            this.versionString = versionString;
        }

        public override string ToString()
        {
            return versionString;
        }
        public void SetString(string ver)
        {
            versionString = ver;
        }
        public static bool operator >(Version c1, Version c2)
        {
            return (VersionHelper.VersionsCompare(c1, c2) > 0);
        }
        public static bool operator <(Version c1, Version c2)
        {
            return (VersionHelper.VersionsCompare(c1, c2) < 0);
        }
        public static bool operator ==(Version c1, Version c2)
        {
            return (VersionHelper.VersionsCompare(c1, c2) == 0);
        }
        public static bool operator !=(Version c1, Version c2)
        {
            return (VersionHelper.VersionsCompare(c1, c2) != 0);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

    }

    /// <summary>
    /// Вспомогательный класс с инструментами
    /// </summary>
    internal static class VersionHelper
    {
        public static int VersionsCompare(Version v1, Version v2)
        {
            List<int> l1 = VersionToList(v1.ToString());
            List<int> l2 = VersionToList(v2.ToString());
            SizeEqualize(ref l1, ref l2);
            return ListsCompare(l1, l2);
        }
        private static List<int> VersionToList(string version)
        {
            List<int> result = new();
            foreach (string s in version.Split('.'))
            {
                result.Add(int.Parse(s));
            }
            return result;
        }

        private static void SizeEqualize(ref List<int> l1, ref List<int> l2)
        {
            if (l1.Count == l2.Count)
                return;

            if (l1.Count > l2.Count)
                ListFill(ref l2, l1.Count - l2.Count, 0);
            else
                ListFill(ref l1, l2.Count - l1.Count, 0);
        }

        private static void ListFill<T>(ref List<T> list, int count, T value)
        {
            for (int i = 0; i < count; i++)
            {
                list.Add(value);
            }
        }

        private static int ListsCompare(List<int> ver1, List<int> ver2)
        {
            SizeEqualize(ref ver1, ref ver2);

            for (int i = 0; i < ver1.Count; i++)
            {
                int diff = ver1[i] - ver2[i];
                if (diff == 0) continue;
                return Math.Sign(diff);
            }
            return 0;
        }
    }
}
