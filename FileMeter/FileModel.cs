using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMeter
{
    public partial class FileModel : ObservableObject
    {
        public FileModel(DirectoryModel directory, FileInfo fileInfo)
        {
            Directory = directory;
            Name = fileInfo.Name;
            Size = fileInfo.Length;
            Directory.AddSize(Size);
        }

        public DirectoryModel Directory { get; private set; }
        public string Name { get; private set; }
        public long Size { get; private set; }
    }
}
