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
