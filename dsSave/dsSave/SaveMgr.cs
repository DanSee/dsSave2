using System;
using System.Collections.Generic;
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

        private const string REGKEY_SAVEDIR = "UserSaveDir";
        private const string REGEKEY_LASTVIEWED = "LastViewedDir";


        //private const string DEFAULT_SAVE_NAME = @"DRAKS0005.sl2";
        private const string DEFAULT_SAVE_NAME = @"DARKSII0000.sl2";

        private const string DEFAULT_QUICKSAVE_NAME = @"quickSave";
        private const string DEFAULT_AUTOSAVE_NAME = @"autoSave";
        private const string AUTO_SAVE_DIR = @"_autoSaveGames\";
        private const string QUICK_SAVE_DIR = @"_quickSaveGames\";
        private const string CUSTOM_SAVE_DIR = @"_customSaveGames\";
        private const string MAINBACKUP_SAVE_DIR = @"_MainSaveFileBackups\";

        private const long SAVE_SIZE = 4330480;

        private string currentlyViewedDirectory;

        private string userSaveDir;
        public string dsCustomSaveDir;
        public string dsQuickSaveDir;
        public string dsAutoSaveDir;
        public string dsMainBackupSaveDir;
        private string dsMainSave = "";
        private string dsQuickSave = "";
        private string dsAutoSave = "";

        private int currentAutoSaveNumber;

        private readonly Label displayLabel;
        private readonly Label timeStampLabel;

        public SaveMgr(Label lblDisplay, Label lblTimeStamp)
        {
            displayLabel = lblDisplay;
            timeStampLabel = lblTimeStamp;
        }

        public void confirmOverwrite(string dataToSave, string gameSaveName)
        {
            DialogResult resultOfDelete = MessageBox.Show("Saving will overwrite " + gameSaveName + ", Continue?",
                "confirmation", MessageBoxButtons.YesNoCancel);

            if (resultOfDelete == DialogResult.Yes)
            {
                File.Copy(dsMainSave, dataToSave, true);
            }
        }

        public void deleteSelectedSave(string selected)
        {
            if (selected == DEFAULT_SAVE_NAME)
            {
                MessageBox.Show("You can not delete the main game save.");
            }
            else if (File.Exists(currentlyViewedDirectory + selected))
            {
                DialogResult resultOfDelete = MessageBox.Show("Are you sure you want to delete " + selected + "?",
                    "confirmation", MessageBoxButtons.YesNoCancel);

                if (resultOfDelete == DialogResult.Yes)
                {
                    if (File.Exists(currentlyViewedDirectory + selected))
                    {
                        File.Delete(currentlyViewedDirectory + selected);
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

        public void saveCustom(string gameSaveName)
        {
            getSaveDirRefs();
            string dataToSave = dsCustomSaveDir + gameSaveName;

            if (File.Exists(dsMainSave))
            {
                if (File.Exists(dataToSave))
                {
                    confirmOverwrite(dataToSave, gameSaveName);
                }
                else
                {
                    File.Copy(dsMainSave, dataToSave, true);
                }
                printLabel("Saved " + gameSaveName, "Saved custom");
            }
            else
            {
                MessageBox.Show("The main save data is missing.");
                printLabel("Save data missing", "Failed custom save");
            }
        }

        public void loadCustomClick(string selected)
        {
            getSaveDirRefs();
            string selectedSave = currentlyViewedDirectory + selected;
            FileInfo selectedSaveData = new FileInfo(selectedSave);

            if (File.Exists(selectedSave))
            {
                if (selectedSaveData.Length == SAVE_SIZE)
                {
                    File.Copy(dsMainSave, dsMainBackupSaveDir + DEFAULT_SAVE_NAME + "." + getTimestamp(".dd_MMM_yyyy.hh;mm;sstt"), true);
                    File.Copy(selectedSave, dsMainSave, true);
                    printLabel("Loaded: " + selected, "Loaded custom");
                }
                else
                {
                    MessageBox.Show(selected + "  is not a valid save file. " + Environment.NewLine +
                                    "(if this IS in fact a valid save file, give it a .sl2 extention and try to load again.)");
                }
            }
            else
            {
                MessageBox.Show("File no longer exists");
            }

        }

        public void quickSaveClick()
        {
            getSaveDirRefs();

            if (isSaveDataValid())
            {
                string highestNumber = getHighestSaveNumber(true);
                string newSaveName = dsQuickSaveDir + highestNumber + "." + DEFAULT_QUICKSAVE_NAME +
                                     getTimestamp(".dd_MMM_yyyy.hh-mm.sstt");
                File.Copy(dsMainSave, newSaveName);
                printLabel("QuickSave", "Quicksave");
            }
            else
            {
                MessageBox.Show("Save data is not valid", "Failed  quicksave");
            }
        }

        public void loadQuicksaveClick()
        {
            getSaveDirRefs();

            DirectoryInfo directory = new DirectoryInfo(dsQuickSaveDir);
            FileInfo[] files = directory.GetFiles();

            if (files.Length != 0)
            {
                string currentSaveNumber = getHighestSaveNumber();
                int currentNumber;
                string fileToLoad = ""; 

                foreach (FileInfo f in files)
                {
                    int currSaveNum;
                    int.TryParse(currentSaveNumber, out currSaveNum);
                    bool isValidNumber = int.TryParse(f.Name.Substring(0, 2), out currentNumber);
                    if (isValidNumber &&  currSaveNum == currentNumber)
                    {
                        fileToLoad = f.Name;
                    }
                }

                File.Copy(dsMainSave, dsMainBackupSaveDir + DEFAULT_SAVE_NAME + "." + getTimestamp(".dd_MMM_yyyy.hh;mm;sstt"), true);
                File.Copy(dsQuickSaveDir + fileToLoad, dsMainSave, true);
                setCurrentlyViewedDirectory(dsQuickSaveDir);
                printLabel("Loaded most recent Quicksave", "Quicksave loaded");
            }
            else
            {
                printLabel("There is no quicksave file to load!", "Failed loading quicksave");
            }
        }

        private string getHighestSaveNumber(bool incrementNumber = false)
        {
            int highestNumber = 0;
            string returnString;
            DirectoryInfo directory = new DirectoryInfo(dsQuickSaveDir);
            FileInfo[] files = directory.GetFiles();
            if (files.Length != 0)
            {
                List<int> allNumbers = new List<int>();
                foreach (FileInfo f in files)
                {
                    bool isValidSave = int.TryParse(f.Name.Substring(0, 2), out highestNumber);
                    if (isValidSave)
                    {
                        allNumbers.Add(highestNumber);
                    }

                }
                if (allNumbers.Count > 0)
                {
                    highestNumber = allNumbers.Max();
                }
            }

            if (incrementNumber)
            {
                highestNumber++;
            }
            if (highestNumber < 10)
            {
                returnString = "0" + highestNumber; 
            }
            else
            {
                returnString = highestNumber.ToString(); 
            }


            return returnString;
        }

        public void refreshSavedGames(ListBox lstBoxSavedGames, string currentDirectory)
        {
            getSaveDirRefs();
            lstBoxSavedGames.Items.Clear();

            if (Directory.Exists(currentDirectory))
            {
                DirectoryInfo info = new DirectoryInfo(currentDirectory);
                FileInfo[] files = info.GetFiles();

                foreach (FileInfo f in files)
                {
                    lstBoxSavedGames.Items.Add(f.Name);
                }

               setCurrentlyViewedDirectory(currentDirectory);
            }
            else
            {
                lstBoxSavedGames.Items.Add("Nothing to show for this directory.");
            }
        }

        public void refreshSavedGames(ListBox lstBoxSavedGames)
        {
            getSaveDirRefs();
            lstBoxSavedGames.Items.Clear();

            if (Directory.Exists(currentlyViewedDirectory))
            {
                DirectoryInfo info = new DirectoryInfo(currentlyViewedDirectory);
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

        public void checkForSavePath()
        {
          //  userSaveDir = getUserSaveDir();
            userSaveDir = @"C:\Users\dann\AppData\Roaming\DarkSoulsII\0110000105e1a214\";
            dsMainSave = userSaveDir + DEFAULT_SAVE_NAME;
            while (!isSaveDataValid())
            {
                saveUserDirInRegistry();
                dsMainSave = userSaveDir + DEFAULT_SAVE_NAME;
            }
           

            dsAutoSaveDir = userSaveDir + AUTO_SAVE_DIR;
            dsQuickSaveDir = userSaveDir + QUICK_SAVE_DIR;
            dsCustomSaveDir = userSaveDir + CUSTOM_SAVE_DIR;
            dsMainBackupSaveDir = userSaveDir + MAINBACKUP_SAVE_DIR;

            dsAutoSave = dsAutoSaveDir + DEFAULT_AUTOSAVE_NAME;
            dsQuickSave = dsQuickSaveDir + DEFAULT_QUICKSAVE_NAME;

            createDirIfNotExist(dsCustomSaveDir);
            createDirIfNotExist(dsAutoSaveDir);
            createDirIfNotExist(dsQuickSaveDir);
            createDirIfNotExist(dsMainBackupSaveDir);

            getSaveDirRefs();
        }

        private void createDirIfNotExist(string dirName)
        {
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
        }

        public bool isSaveDataValid()
        {
            return File.Exists(dsMainSave);
        }

    

        public void saveUserDirInRegistry()
        {
            string prompt = "Please enter your Dark souls game save directory." + Environment.NewLine + Environment.NewLine
                       + "Your save directory should be something like: " + Environment.NewLine + Environment.NewLine
                       + @"C:\Users\_windowsUsername_\Documents\NBGI\DarkSouls\_windowsLiveUsername_\";
            string title = @"Set save game directory";
            string defaultText = @"C:\Users\dann\AppData\Roaming\DarkSoulsII\0110000105e1a214";

            string defaultText1 = @"C:\Users\WINDOWS_USERNAME\Documents\NBGI\DarkSouls\WINDOWS_LIVE_USERNAME";

            userSaveDir = Microsoft.VisualBasic.Interaction.InputBox(prompt, title, defaultText, -1, -1);
            if (!userSaveDir.EndsWith("\\"))
            {
                userSaveDir += "\\";
            }
            while (!Directory.Exists(userSaveDir) || !File.Exists(userSaveDir + DEFAULT_SAVE_NAME))
            {
                DialogResult tryAgain = MessageBox.Show("That was not a valid directory, try again?", "confirmation", MessageBoxButtons.YesNo);
                userSaveDir = Microsoft.VisualBasic.Interaction.InputBox(prompt, title, userSaveDir, -1, -1);
            }

            setRegistryKey(REGKEY_SAVEDIR, userSaveDir);
        }


        private void setCurrentlyViewedDirectory(string currentDir)
        {
            currentlyViewedDirectory = currentDir;
            RegKeyMgr.setKey(REGEKEY_LASTVIEWED, currentlyViewedDirectory);
        }

        private void setRegistryKey(string valueName, string keyValue )
        {
            try
            {
                RegKeyMgr.setKey(valueName, keyValue);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        public void getSaveDirRefs()
        {
            dsMainSave = "";
            dsQuickSave = "";
            //userSaveDir = getUserSaveDir();
            userSaveDir = @"C:\Users\dann\AppData\Roaming\DarkSoulsII\0110000105e1a214\";
            dsMainSave = userSaveDir + DEFAULT_SAVE_NAME;
            dsQuickSave = userSaveDir  + QUICK_SAVE_DIR + DEFAULT_QUICKSAVE_NAME;
            dsAutoSave = userSaveDir  + AUTO_SAVE_DIR + DEFAULT_AUTOSAVE_NAME;

            currentlyViewedDirectory =   RegKeyMgr.getRegKey(REGEKEY_LASTVIEWED);
            if (currentlyViewedDirectory == "")
            {
                currentlyViewedDirectory = userSaveDir;
            }
        }


        private string getUserSaveDir()
        {
            string rSaveDir = RegKeyMgr.getRegKey(REGKEY_SAVEDIR);
            if (!rSaveDir.EndsWith("\\"))
            {
                rSaveDir += "\\";
            }
            return rSaveDir;
        }

        private string getTimestamp(string format)
        {
            return DateTime.Now.ToString(format);
        }

        private void printLabel(string text, string lastAction)
        {
            displayLabel.Text = text;
            timeStampLabel.Text = "Last action @ " + getTimestamp("HH:mm:ss") + " - Action was: " + lastAction;
        }
    }
}
