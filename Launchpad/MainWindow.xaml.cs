using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Launchpad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<FolderInfo> FolderList { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            string[] dirs = Directory.GetDirectories(@"C:\Users\omkar\code library\projects");

            foreach(string dir in dirs)
            {
                FolderList.Add(new FolderInfo
                {
                    Name = System.IO.Path.GetFileName(dir),
                    FullPath = dir
                });
            }
        }

        /*private void LoadFolders(string path)
        {
            if (!Directory.Exists(path))
            {
                MessageBox.Show("Directory does not exist.");
                return;
            }

            try
            {
                string[] directories = Directory.GetDirectories(path);
                FolderList.Clear();
                foreach (var dir in directories)
                {
                    FolderList.Add(System.IO.Path.GetFileName(dir)); // Add full path if needed
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading folders: {ex.Message}");
            }
        }*/

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string idea64 = @"C:\Program Files\JetBrains\IntelliJ IDEA Community Edition 2025.1.4.1\bin\idea64.exe";
            string projectName, projectPath;

            if(lbFolders.SelectedItem is FolderInfo folder)
            {
                projectName = folder.Name;
                projectPath = folder.FullPath;
                MessageBox.Show("Launching: " + projectName + "\nFrom: " + projectPath);

                Process.Start(new ProcessStartInfo
                {
                    FileName = idea64,
                    Arguments = $"\"{projectPath}\"",
                    UseShellExecute = true
                });
            }
        }
        private void ListView_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            if(lbFolders.SelectedItem is FolderInfo folder)
            {
                tbPath.Text = folder.FullPath;
            }
        }
    }
}