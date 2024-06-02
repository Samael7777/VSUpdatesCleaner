# VSUpdatesCleaner

Description:
  Visual Studio local packages cleaner.

Usage:
  VSUpdatesCleaner [command] [options]

Options:
  --catalog-file <catalog-file>    Path to Catalog.json. [default: <App path>]
  --packages-path <packages-path>  Path to downloaded packages directory. [default: <App path>]
  --version                        Show version information
  -?, -h, --help                   Show help and usage information

Commands:
  info           Print unused packages information (default).
  delete         Delete unused packages.
  move <target>  Move unused packages to target directory.