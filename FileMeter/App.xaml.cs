using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FileMeter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RootDirectory = dialog.SelectedPath;
                //RootDirectory = @"C:\Users\Ivan\.IdeaIC13\system\compile-server\playground_3477729d\timestamps";
                base.OnStartup(e);
            }
        }

        public static string RootDirectory { get; set; }
    }
}
