using System.Diagnostics;
using System.Windows;

namespace Launchpad.HelperMethods
{
    public static class OpenIn
    {
        public static void IntelliJ(FolderInfo folder)
        {
            if (folder == null) return;

            string idea64 = @"C:\Program Files\JetBrains\IntelliJ IDEA Community Edition 2025.1.4.1\bin\idea64.exe";

            MessageBox.Show("Launching: " + folder.Name + "\nFrom: " + folder.FullPath + "\n IntelliJ Idea");

            Process.Start(new ProcessStartInfo
            {
                FileName = idea64,
                Arguments = $"\"{folder.FullPath}\"",
                UseShellExecute = true
            });
        }

        public static void NotepadPlusPlus(FolderInfo folder)
        {
            if (folder == null) return;

            string notepadPlusPlus = @"C:\Program Files\Notepad++\notepad++.exe";

            MessageBox.Show("Launching: " + folder.Name + "\nFrom: " + folder.FullPath + "\n IntelliJ Idea");

            Process.Start(new ProcessStartInfo
            {
                FileName = notepadPlusPlus,
                Arguments = $"\"{folder.FullPath}\"",
                UseShellExecute = true
            });
        }
    }
}
