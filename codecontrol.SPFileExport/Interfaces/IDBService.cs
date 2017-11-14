using System;
using codecontrol.SPFileExport.Models;

namespace codecontrol.SPFileExport.Interfaces
{
    public interface IDBService
    {
        SPFileCollection StartExport();
    }
}
