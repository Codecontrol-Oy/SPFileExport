# SharePoint ContentDB document exporter

* Tool for extracting documents added and updated through SharePoint
* Tested with SP 2010

Note: Tool only exports the latest version of every document

Tool fetches document metadatas from **AllDocs** Table, and joins the data with the latest version of the document from **AllDocStreams** -table

Exports documents inside contentdb to the solution directory:

```
/files/folder/filename
/files/folder2/filename2
/files/folder2/filename3
/files/folder3/filename4
```

After all documents have been exported, a filelist.txt is created to see all exported files.

## Dotnet installation

This software is created with .net core 1.1

for macOS: https://www.microsoft.com/net/learn/get-started/macos

for Windows: https://www.microsoft.com/net/learn/get-started/windows

for Linux: 
  * Ubuntu: https://www.microsoft.com/net/learn/get-started/linuxubuntu
  * RHEL: https://www.microsoft.com/net/learn/get-started/linuxredhat
  * Debian: https://www.microsoft.com/net/learn/get-started/linuxdebian
  * Fedora: https://www.microsoft.com/net/learn/get-started/linuxfedora
  * CentOS: https://www.microsoft.com/net/learn/get-started/linuxcentos
  * openSuse: https://www.microsoft.com/net/learn/get-started/linuxopensuse
  
if the above links are offering newer than 1.1, visit https://github.com/dotnet/core/blob/master/release-notes/download-archive.md



## Program installation

1. Clone this project
```
git clone https://github.com/Codecontrol-Oy/SPFileExport
```
2. inside folder main folder, run the following commands:
```
dotnet restore
dotnet build
```

## Using the application

To start the export program, go inside the codecontrol.SPFileExport -project folder and run the following command:
```
dotnet run
```
If you are using windows, you can also run the builded .exe from bin/debug/netcoreapp1.1 -folder.

Inside the program:
* Type the address of your MS Sql Server
* Type the name of your target contentdb, which to export documents from
* Type Y if you wish to use integrated security (The AD account you are logged in with), or N to enter username and password for your connection. 



