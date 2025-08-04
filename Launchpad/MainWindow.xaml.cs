using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Launchpad.HelperMethods;

namespace Launchpad
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<FolderInfo> FolderList { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            string[] dirs = Directory.GetDirectories(@"C:\Users\omkar\code library\projects");

            foreach (string dir in dirs)
            {
                FolderList.Add(new FolderInfo
                {
                    Name = System.IO.Path.GetFileName(dir),
                    FullPath = dir
                });
            }
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbFolders.SelectedItem is FolderInfo folder)
            {
                OpenIn.IntelliJ(folder);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lbFolders.SelectedItem is FolderInfo folder)
            {
                OpenIn.IntelliJ(folder);
            }
        }

        private void ListView_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            if (lbFolders.SelectedItem is FolderInfo folder)
            {
                tbPath.Text = folder.FullPath;
                var root = BuildTree(folder.FullPath);
                tvFolderTree.ItemsSource = new List<FileSystemItem> { root };
            }
            else
            {
                tvFolderTree.ItemsSource = null;
            }
        }

        private FileSystemItem BuildTree(string folderPath)
        {
            var item = new FileSystemItem
            {
                Name = Path.GetFileName(folderPath),
                FullPath = folderPath,
                IsFolder = true
            };

            // Add subfolders
            foreach (var dir in Directory.GetDirectories(folderPath))
            {
                item.Children.Add(BuildTree(dir));
            }

            // Add files
            foreach (var file in Directory.GetFiles(folderPath))
            {
                item.Children.Add(new FileSystemItem
                {
                    Name = Path.GetFileName(file),
                    FullPath = file,
                    IsFolder = false
                });
            }

            return item;
        }


        private void OpenIn_explorer(object sender, RoutedEventArgs e)
        {
            if (lbFolders.SelectedItem is FolderInfo folder && Directory.Exists(folder.FullPath))
                Process.Start("explorer.exe", $"\"{folder.FullPath}\"");
        }

        private void OpenIn_cmd(object sender, RoutedEventArgs e)
        {
            if (lbFolders.SelectedItem is FolderInfo folder)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/K cd /d \"{folder.FullPath}\"",
                    UseShellExecute = true
                });
            }
        }

        private void Button_NotepadPlusPlus(object sender, RoutedEventArgs e)
        {
            if (lbFolders.SelectedItem is FolderInfo folder)
            {
                OpenIn.NotepadPlusPlus(folder);
            }
        }

        private void Btn_CopyPath(object sender, RoutedEventArgs e)
        {
            if (lbFolders.SelectedItem is FolderInfo folder)
            {
                Clipboard.SetText(folder.FullPath);
            }
        }
    }
}