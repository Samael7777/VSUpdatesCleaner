using System.CommandLine;
using VSUpdatesCleaner;



/*----------Описание аргументов командной строки---------------*/
//Аргументы
var SrcDirArg = new Argument<DirectoryInfo>(
    name: "Source",
    description: "Путь к папке с компонентами Visual Studio");
//getDefaultValue: () => new DirectoryInfo(Directory.GetCurrentDirectory()));

var DstDirArg = new Argument<DirectoryInfo>(
    name: "Destination",
    description: "Путь к папке, куда перемещать устаревшие компоненты");

//Команды
var cmdScan = new Command(
    "SCAN",
    description: "Сканирование исходной папки на дубликаты");
cmdScan.AddAlias("-s");
cmdScan.AddArgument(SrcDirArg);

var cmdMove = new Command(
    "MOVE",
    "Перемещение дубликатов в указанную папку");
cmdMove.AddAlias("-m");
cmdMove.AddArgument(SrcDirArg);
cmdMove.AddArgument(DstDirArg);

var cmdDel = new Command(
    "DEL",
    "Удаление дубликатов");
cmdDel.AddAlias("-d");
cmdDel.AddArgument(SrcDirArg);

var rootCommand = new RootCommand
    {
        cmdDel,
        cmdMove,
        cmdScan
    };
rootCommand.Description = "Утилита для поиска и удаления дубликатов " +
    "установочных компонентов Visual Studio";

/*-------------Обработчик аргументов командной строки--------*/

//Сканирование
cmdScan.SetHandler((DirectoryInfo src) =>
{
    try
    {
        Processor.SourceDirectory = src;
        Processor.Scan();
    }
    catch (Exception e)
    {
        Console.WriteLine($"Ошибка: {e.Message}");
    }
}, SrcDirArg);

//Удаление
cmdDel.SetHandler((DirectoryInfo src) =>
{
    try
    {
        Processor.SourceDirectory = src;
        Processor.Delete();
    }
    catch (Exception e)
    {
        Console.WriteLine($"Ошибка: {e.Message}");
    }
}, SrcDirArg);

//Перемещение
cmdMove.SetHandler((DirectoryInfo src, DirectoryInfo dst) =>
{
    try
    {
        Processor.SourceDirectory = src;
        Processor.Move(dst);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Ошибка: {e.Message}");
    }
}, SrcDirArg, DstDirArg);


if (args.Length > 0)
    rootCommand.Invoke(args);
else
    rootCommand.Invoke("--help");

Console.WriteLine();
Console.WriteLine("Нажмите любую клавишу для выхода...");
Console.ReadKey();