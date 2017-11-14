using System;
using System.Collections.Generic;
using codecontrol.SPFileExport.Models;

namespace codecontrol.SPFileExport.Interfaces
{
    public interface ISPFileCollection : IList<SPFile>
    {
        void WriteFileList();
    }
}
