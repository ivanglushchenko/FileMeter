using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMeter
{
    public partial class FileModel : FileSystemObject
    {
        public FileModel(DirectoryModel directory, FileInfo fileInfo)
        {
            Directory = directory;
            Name = fileInfo.Name;
            Size = fileInfo.Length;
        }

        public DirectoryModel Directory { get; private set; }

        public override string ToString()
        {
            return string.Format("File: {0}", Name);
        }
    }
}
