using System;
using System.Collections.Generic;
using System.IO;
using codecontrol.SPFileExport.Interfaces;

namespace codecontrol.SPFileExport.Models
{
    public class SPFileCollection : List<SPFile>
    {
        public virtual void WriteFileList()
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
