using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItunesMusicComparer.Classes
{
    class FileData
    {
        public string FileName { get; set; }
        public string FullPath { get; set; }

        public FileData(string fileName, string fullPath)
        {
            FileName = fileName;
            FullPath = fullPath;
        }
    }
}
