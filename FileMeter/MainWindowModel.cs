using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMeter
{
    public partial class MainWindowModel : ObservableObject
    {
        public MainWindowModel()
        {
            Root = new DirectoryModel(null, new DirectoryInfo(App.RootDirectory));
            Root.Traverse();
        }

        /// <summary>
        /// Gets/sets Root.
        /// </summary>
        public DirectoryModel Root
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return p_Root; }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                if (p_Root != value)
                {
                    p_Root = value;
                    OnPropertyChanged("Root");
                    OnRootChanged();
                }
            }
        }
        private DirectoryModel p_Root;
        partial void OnRootChanged();


    }
}
