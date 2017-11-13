using System;
using System.Collections.Generic;
using System.IO;

namespace codecontrol.SPFileExport.Models
{
    public class SPFileCollection : List<SPFile>
    {
        public void WriteFileList()
        {
            using (var writer = File.CreateText("filelist.txt"))
            {
                foreach (var file in this)
                {
                    writer.WriteLine($"files/{file.DataFolder}/{file.Filename}");
                }
            }
        }
    }
}
