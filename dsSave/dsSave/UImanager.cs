using System.IO;
using System.Windows.Forms;

namespace dsSave
{
    internal class UImanager 
    {
        public RealSaveManager _realSave = new RealSaveManager();

        public void refreshSavedGames(ListBox lstBoxSavedGames, string currentDirectory)
        {
            _realSave.getSaveDirRefs();
            lstBoxSavedGames.Items.Clear();

            if (Directory.Exists(currentDirectory))
            {
                DirectoryInfo info = new DirectoryInfo(currentDirectory);
                FileInfo[] files = info.GetFiles();

                foreach (FileInfo f in files)
                {
                    lstBoxSavedGames.Items.Add(f.Name);
                }

                _realSave.setCurrentlyViewedDirectory(currentDirectory);
            }
            else
            {
                lstBoxSavedGames.Items.Add("Nothing to show for this directory.");
            }
        }

        public void refreshSavedGames(ListBox lstBoxSavedGames)
        {
            _realSave.getSaveDirRefs();
            lstBoxSavedGames.Items.Clear();

            if (Directory.Exists(_realSave.currentlyViewedDirectory))
            {
                DirectoryInfo info = new DirectoryInfo(_realSave.currentlyViewedDirectory);
                FileInfo[] files = info.GetFiles();

                foreach (FileInfo f in files)
                {
                    lstBoxSavedGames.Items.Add(f.Name);
                }
            }
            else
            {
                lstBoxSavedGames.Items.Add("Nothing to show for this directory.");
            }
        }
    }
}
