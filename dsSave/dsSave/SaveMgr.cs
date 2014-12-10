using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dsSave
{
    internal class SaveMgr 
    {


        //private const string DEFAULT_SAVE_NAME = @"DRAKS0005.sl2";
       // private const string DEFAULT_SAVE_NAME = @"DARKSII0000.sl2";

        

        public Save _slug = new SaveQuick();

        public RealSaveManager _realSave = new RealSaveManager();
        
        private int currentAutoSaveNumber;

        private readonly Label displayLabel;
        private readonly Label timeStampLabel;

        public SaveMgr(Label lblDisplay, Label lblTimeStamp)
        {
            displayLabel = lblDisplay;
            timeStampLabel = lblTimeStamp;
        }


        public void deleteSelectedSave(string selected)
        {
           
            if (selected == DEFAULT_SAVE_NAME)
            {
                MessageBox.Show("You can not delete the main game save.");
            }
            else if (File.Exists(_realSave.currentlyViewedDirectory + selected))
            {
                DialogResult resultOfDelete = MessageBox.Show("Are you sure you want to delete " + selected + "?",
                    "confirmation", MessageBoxButtons.YesNoCancel);

                if (resultOfDelete == DialogResult.Yes)
                {
                    if (File.Exists(_realSave.currentlyViewedDirectory + selected))
                    {
                        File.Delete(_realSave.currentlyViewedDirectory + selected);
                    }
                    else
                    {
                        MessageBox.Show("The selected file does not exist.");
                    }
                }
            }
            else
            {
                MessageBox.Show("The selected file does not exist.");
            }
        }



        public void loadCustomClick(string selected)
        {
            _realSave.customSaveClick();
        }


        public void loadQuicksaveClick()
        {
            _realSave.quickSaveClick();
        }

        public void loadAutoClick(string selected)
        {
            _realSave.customSaveClick();
        }

        


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
     


        private void firstRun()
        {
            if (_realSave.isSaveDataValid())
            {
                DialogResult setAnyways = MessageBox.Show("Your save directory is already Valid. Set new save directory anyways?",
                    "confirmation",
                    MessageBoxButtons.YesNo);
                if (setAnyways == DialogResult.Yes)
                {
                    _realSave.saveUserDirInRegistry();
                    refreshSavedGames(lstBoxSavedGames);
                }
            }
        }

    

      


        public void checkforSavePath()
        {
            _slug.checkForSavePath();
        }


     

        private string getTimestamp(string format)
        {
            return DateTime.Now.ToString(format);
        }

//
//        private void printLabel(string text, string lastAction)
//        {
//            _slug.printLabel();
//            displayLabel.Text = text;
//            timeStampLabel.Text = "Last action @ " + getTimestamp("HH:mm:ss") + " - Action was: " + lastAction;
//        }

    }
}
