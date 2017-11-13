using System;
using codecontrol.SPFileExport.Services;

namespace codecontrol.SPFileExport
{
    class Program
    {
        
        static void Main(string[] args)
        {
            DBService service = null;
            Console.WriteLine("");
            string message = @"   _  _     _____ _                   ______     _       _    ______ _ _        _____                      _" + Environment.NewLine +             
                             @" _| || |_  /  ___| |                  | ___ \   (_)     | |   |  ___(_) |      |  ___|                    | |" + Environment.NewLine +   
                             @"|_  __  _| \ `--.| |__   __ _ _ __ ___| |_/ /__  _ _ __ | |_  | |_   _| | ___  | |____  ___ __   ___  _ __| |_ ___ _ __ " + Environment.NewLine +
                             @" _| || |_   `--. \ '_ \ / _` | '__/ _ \  __/ _ \| | '_ \| __| |  _| | | |/ _ \ |  __\ \/ / '_ \ / _ \| '__| __/ _ \ '__|" + Environment.NewLine + 
                             @"|_  __  _| /\__/ / | | | (_| | | |  __/ | | (_) | | | | | |_  | |   | | |  __/ | |___>  <| |_) | (_) | |  | ||  __/ |   " + Environment.NewLine + 
                             @"  |_||_|   \____/|_| |_|\__,_|_|  \___\_|  \___/|_|_| |_|\__| \_|   |_|_|\___| \____/_/\_\ .__/ \___/|_|   \__\___|_|   " + Environment.NewLine + 
                             @"                                                                                         | |                            " + Environment.NewLine + 
                             @"                                                                                         |_|                            ";
            Console.WriteLine(message);
            Console.WriteLine("By Codecontrol Oy @2017");
            Console.WriteLine("");
            Console.Write("SQL Server Address: ");
            var server = Console.ReadLine();
            Console.Write("SP Content database name: ");
            var db = Console.ReadLine();
            Console.Write("Use integrated security? (Y/N): ");
            var integrated = Console.ReadLine();
            if (integrated.ToLower() == "y")
            {
                service = new DBService(server, db);
            }
            else 
            {
                
                Console.Write("Username: ");
                var username = Console.ReadLine();
                Console.Write("Password: ");
                var password = Console.ReadLine();
                service = new DBService(server, db,username, password);
            }
            Console.WriteLine("");

            //Export files from Sql Server
            var fetchedFiles = service.ExportFiles();
            //Save filelist
            fetchedFiles.WriteFileList();
            Console.WriteLine("All Done!");
        }
    }
}
