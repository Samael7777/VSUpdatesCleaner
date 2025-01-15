using EasyConsole;

namespace VSUpdatesCleaner.Pages;

public class DeletePage(Program program) : Page("Delete not used packages", program)
{
    public override void Display()
    {
        base.Display();

        if (Settings.CleanerModel == null)
            return;
        
        Output.WriteLine("Delete unused packages...");
        var deleted = Settings.CleanerModel.DeleteUnusedGetDeletedBytes();
        Output.WriteLine(ConsoleColor.Green, $"Freed {deleted.ToFileSizeApi()}");
    }
}