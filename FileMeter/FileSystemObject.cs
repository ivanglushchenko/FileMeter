using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMeter
{
    public abstract partial class FileSystemObject : ObservableObject
    {
        /// <summary>
        /// Gets/sets Name.
        /// </summary>
        public string Name
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return p_Name; }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                if (p_Name != value)
                {
                    p_Name = value;
                    OnPropertyChanged("Name");
                    OnNameChanged();
                }
            }
        }
        private string p_Name;
        partial void OnNameChanged();

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
    }
}
