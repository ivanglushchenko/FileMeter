using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMeter
{
    public partial class DirectoryModel : ObservableObject
    {
        public DirectoryModel(DirectoryModel directory)
        {
            Parent = directory;
        }

        public DirectoryModel Parent { get; private set; }

        /// <summary>
        /// Gets/sets Directories.
        /// </summary>
        public ObservableCollection<DirectoryModel> Directories
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return p_Directories; }
        }
        private ObservableCollection<DirectoryModel> p_Directories = new ObservableCollection<DirectoryModel>();
        partial void OnDirectoriesChanged();

        /// <summary>
        /// Gets/sets Files.
        /// </summary>
        public ObservableCollection<FileModel> Files
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return p_Files; }
        }
        private ObservableCollection<FileModel> p_Files = new ObservableCollection<FileModel>();
        partial void OnFilesChanged();

        /// <summary>
        /// Gets/sets Size.
        /// </summary>
        public long Size
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return p_Size; }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                if (p_Size != value)
                {
                    p_Size = value;
                    OnPropertyChanged("Size");
                    OnSizeChanged();
                }
            }
        }
        private long p_Size;
        partial void OnSizeChanged();

        public void AddSize(long size)
        {
            Size += size;
            if (Parent != null)
                Parent.AddSize(size);
        }
    }
}
