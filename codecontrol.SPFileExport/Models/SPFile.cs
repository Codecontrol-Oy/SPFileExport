using System;
using System.Collections.Generic;

namespace codecontrol.SPFileExport.Models
{
    public class SPFile : List<SPFile>
    {
        public Guid Id { get; set; }
        public string Filename { get; set; }
        public string Extension { get; set; }
        public string DataFolder { get; set; }
    }
}
