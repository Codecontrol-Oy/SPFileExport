using System;
using System.Data.SqlClient;
using System.IO;
using codecontrol.SPFileExport.Models;

namespace codecontrol.SPFileExport.Services
{

    public class DBService
    {
        string DBConnectionString = "";
        string ExportQuery = "Select a.Content, h.Id, h.DirName, h.LeafName, h.Extension, h.Size From (Select Id, Max(InternalVersion) As Latest_Version From AllDocStreams Group By Id) L,AllDocStreams A,AllDocs h Where A.Id = L.Id And A.InternalVersion = L.Latest_Version And H.Id = A.Id";
        SqlConnection connection;
        int FileCount;

        public DBService(string Server, string Database)
        {
            DBConnectionString += $"Server={Server};Database={Database};Integrated Security=SSPI;";
            Initialize();
        }

        public DBService(string Server, string Database, string Username, string Password)
        {
            DBConnectionString += $"Server={Server};Database={Database};User Id={Username};Password={Password}";
            Initialize();
        }

        private void Initialize()
        {
            connection = new SqlConnection(DBConnectionString);
            connection.Open();
            try
            {
                FileCount = GetFileCount();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
            }
        }

        public int GetFileCount()
        {
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT COUNT(*) FROM ({ExportQuery}) as fileCount";
            var result = command.ExecuteScalar();
            return (int)result;
        }

        public SPFileCollection ExportFiles()
        {
            SPFileCollection results = new SPFileCollection();
            var command = connection.CreateCommand();
            command.CommandText = ExportQuery;
            command.CommandTimeout = int.MaxValue;
            var reader = command.ExecuteReader();
            int index = 1;


            while (reader.Read())
            {
                SPFile file = new SPFile();
                file.Id = (Guid)reader["Id"];
                file.DataFolder = (string)reader["DirName"];
                file.Extension = (string)reader["Extension"];
                file.Filename = (string)reader["LeafName"];
                var size = (int)reader["Size"];
                long handlesBytes = 0;

                //Ignore files without extension
                if (!string.IsNullOrEmpty(file.Extension))
                {
                    Console.WriteLine($"{file.Filename} {index}/{FileCount}");
                    Console.WriteLine("#################################################################");                    
                    if (!Directory.Exists("files/" + file.DataFolder))
                    {
                        Directory.CreateDirectory("files/" + file.DataFolder);
                        Console.WriteLine($"Creating directory: files/{file.DataFolder}");
                    }

                    using (FileStream fs = new FileStream("files/" + file.DataFolder + "/" + file.Filename, FileMode.Create, FileAccess.Write))
                    {
                        int bufferSize = 1048576;
                        long startIndex = 0;
                        long retval = 0;
                        byte[] outByte = new byte[bufferSize];
                        Console.WriteLine($"Fetching file from database...");

                        using (var writer = new BinaryWriter(fs))
                        {
                            do
                            {
                                retval = reader.GetBytes(0, startIndex, outByte, 0, bufferSize);
                                startIndex += bufferSize;

                                writer.Write(outByte, 0, (int)retval);
                                handlesBytes += retval;
                                Console.Write("\r{0}", $"File bytes wrote to hard drive: {handlesBytes}/{size} bytes");
                                writer.Flush();
                            } while (retval == bufferSize);
                        }
                    }

                    results.Add(file);
                    Console.WriteLine($"\nFile write finished.");
                    Console.WriteLine("#################################################################");
                    Console.WriteLine("");

                }
                index++;
            }

            return results;
        }

    }
}
