using EasyConsole;

namespace VSUpdatesCleaner.Pages;

public class ActionsPage : MenuPage
{
    public ActionsPage(Program program) : base("Main menu", program,
        new Option("Delete unused packages", () => program.NavigateTo<DeletePage>()),
        new Option("Move unused packages", () => program.NavigateTo<MovePage>()),
        new Option("Exit", () => { })
        ) 
    {}
}