using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launchpad
{
    class FileSystemItem
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public bool IsFolder { get; set; }
        public List<FileSystemItem> Children { get; set; }
        public bool IsExpanded { get; set; }

        public FileSystemItem()
        {
            Children = new List<FileSystemItem>();
        }
    }
}
