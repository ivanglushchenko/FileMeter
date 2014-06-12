using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace FileMeter
{
    public partial class DirectoryModel : FileSystemObject
    {
        public DirectoryModel(DirectoryModel directory, DirectoryInfo info)
        {
            Parent = directory;
            Info = info;
            Name = info.Name;
        }

        private static readonly object _syncObject = new object();

        public DirectoryInfo Info { get; private set; }
        public DirectoryModel Parent { get; private set; }

        /// <summary>
        /// Gets/sets Items.
        /// </summary>
        public ObservableCollection<FileSystemObject> Items
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return p_Items; }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                if (p_Items != value)
                {
                    p_Items = value;
                    OnPropertyChanged("Items");
                    OnItemsChanged();
                }
            }
        }
        private ObservableCollection<FileSystemObject> p_Items;
        partial void OnItemsChanged();

        public void AddSize(long size)
        {
            if (size == 0)
                return;

            lock (_syncObject)
            {
                Size += size;
            }
            if (Parent != null)
            {
                Parent.AddSize(size);
                Parent.MoveItemUpIfNeeded(this);
            }
        }

        public void MoveItemUpIfNeeded(DirectoryModel dir)
        {
            lock (_syncObject)
            {
                var oldIndex = Items.IndexOf(dir);
                if (oldIndex == 0)
                    return;

                var newIndex = oldIndex;
                while (newIndex > 0)
                {
                    if (Items[newIndex - 1].Size < Items[oldIndex].Size)
                        newIndex--;
                    else
                        break;
                }
                if (newIndex < oldIndex)
                    App.Current.Dispatcher.Invoke((Action)(() => Items.Move(oldIndex, newIndex)));
            }
        }

        public override string ToString()
        {
            return string.Format("Dir: {0}", Name);
        }

        public void Traverse()
        {
            try
            {
                var files = Info.GetFiles().Select(t => new FileModel(this, t)).OrderByDescending(t => t.Size).ToList();
                var directories = Info.GetDirectories().Select(t => new DirectoryModel(this, t)).ToList();
                var items = new ObservableCollection<FileSystemObject>();
                files.ForEach(items.Add);
                directories.ForEach(items.Add);
                Items = items;

                AddSize(files.Sum(t => t.Size));

                foreach (var item in directories)
                {
                    Task.Factory.StartNew(item.Traverse);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    Name = string.Format("{0}: ACCESS DENIED", Info.Name);
                }));
            }
        }
    }
}
