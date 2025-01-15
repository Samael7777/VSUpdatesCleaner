// ReSharper disable LocalizableElement

using EasyConsole;
using VSUpdatesCleaner.Pages;

namespace VSUpdatesCleaner;

public class VsCleanerMain : Program
{
    public VsCleanerMain(string[] args) : base("Visual Studio offline installation source cleaner", true)
    {
        AddPage(new BootstrapPage(this, args));
        AddPage(new ActionsPage(this));
        AddPage(new MovePage(this));
        AddPage(new DeletePage(this));
        SetPage<BootstrapPage>();
    }
}