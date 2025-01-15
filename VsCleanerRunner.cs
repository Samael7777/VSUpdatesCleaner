namespace VSUpdatesCleaner;

public class VsCleanerRunner
{
    [STAThread]
    private static void Main(string[] args)
    {
        new VsCleanerMain(args).Run();
    }
}