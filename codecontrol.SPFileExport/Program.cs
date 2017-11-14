using System;
using codecontrol.SPFileExport.Interfaces;
using codecontrol.SPFileExport.Services;
namespace codecontrol.SPFileExport
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            Start(new ConsoleService(),null);
        }

        public static void MockMain(DBService MockedService, ConsoleService MockedConsole)
        {
            Start(MockedConsole,MockedService);
        }


        static void Start(ConsoleService _consoleService,DBService _dbService = null)
        {
            IDBService service = null;
            _consoleService.WriteLineToConsole("");
            string message = @"   _  _     _____ _                   ______     _       _    ______ _ _        _____                      _" + Environment.NewLine +
                             @" _| || |_  /  ___| |                  | ___ \   (_)     | |   |  ___(_) |      |  ___|                    | |" + Environment.NewLine +
                             @"|_  __  _| \ `--.| |__   __ _ _ __ ___| |_/ /__  _ _ __ | |_  | |_   _| | ___  | |____  ___ __   ___  _ __| |_ ___ _ __ " + Environment.NewLine +
                             @" _| || |_   `--. \ '_ \ / _` | '__/ _ \  __/ _ \| | '_ \| __| |  _| | | |/ _ \ |  __\ \/ / '_ \ / _ \| '__| __/ _ \ '__|" + Environment.NewLine +
                             @"|_  __  _| /\__/ / | | | (_| | | |  __/ | | (_) | | | | | |_  | |   | | |  __/ | |___>  <| |_) | (_) | |  | ||  __/ |   " + Environment.NewLine +
                             @"  |_||_|   \____/|_| |_|\__,_|_|  \___\_|  \___/|_|_| |_|\__| \_|   |_|_|\___| \____/_/\_\ .__/ \___/|_|   \__\___|_|   " + Environment.NewLine +
                             @"                                                                                         | |                            " + Environment.NewLine +
                             @"                                                                                         |_|                            ";
            _consoleService.WriteLineToConsole(message);
            _consoleService.WriteLineToConsole("By Codecontrol Oy @2017");
            _consoleService.WriteLineToConsole("");
            _consoleService.WriteToConsole("SQL Server Address: ");
            var server = _consoleService.ReadInput();
            _consoleService.WriteToConsole("SP Content database name: ");
            var db = _consoleService.ReadInput();
            _consoleService.WriteToConsole("Use integrated security? (Y/N): ");
            var integrated = _consoleService.ReadInput();
            if (integrated.ToLower() == "y")
            {
                service = _dbService == null ? new DBService(server, db) : _dbService;
            }
            else
            {

                _consoleService.WriteToConsole("Username: ");
                var username = _consoleService.ReadInput();
                _consoleService.WriteToConsole("Password: ");
                var password = _consoleService.ReadInput();
                service = _dbService == null ? new DBService(server, db, username, password) : _dbService;
            }
            _consoleService.WriteToConsole("");

            //Export files from Sql Server
            var results = service.StartExport();
            _consoleService.WriteLineToConsole($"All Done, exported {results.Count} documents!");
        }
    }
}
