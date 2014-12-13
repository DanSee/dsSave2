using System;
using System.IO;
using System.Windows.Forms;

namespace dsSave
{
    public class RealSaveManager
    {
        private const string REGKEY_SAVEDIR = "UserSaveDir";
        private const string REGEKEY_LASTVIEWED = "LastViewedDir";
        private const string DEFAULT_QUICKSAVE_NAME = @"quickSave";
        private const string DEFAULT_AUTOSAVE_NAME = @"autoSave";
        private const string DEFAULT_SAVE_NAME = @"DARKSII0000.sl2";
        public const string QUICK_SAVE_DIR = @"_quickSaveGames\";
        public const string CUSTOM_SAVE_DIR = @"_customSaveGames\";
        private const string AUTO_SAVE_DIR = @"_autoSaveGames\";
        public const string MAINBACKUP_SAVE_DIR = @"_MainSaveFileBackups\";
        private const long SAVE_SIZE = 7203104;

        public Save _auto = new SaveAuto();
        public Save _custom = new SaveCustom();
        public Save _quick = new SaveQuick();

        private string userSaveDir, dsMainBackupSaveDir,  dsMainSave ;
        public string currentlyViewedDirectory, dsCustomSaveDir, dsQuickSave, dsAutoSave, dsQuickSaveDir, dsAutoSaveDir;
        
        public bool customSaveClick(string gameSaveName)
        {
            getSaveDirRefs();
            bool success = false;

            if (File.Exists(dsMainSave))
            {
                _custom.doMySaveFuckYea(dsMainSave, gameSaveName, dsCustomSaveDir);
                success = true;
            }
            else
            {
                MessageBox.Show("The main save data is missing.");
            }

            return success;
        }

        public bool loadCSClick(String selected)
        {
            bool success = false;
            string selectedSave = currentlyViewedDirectory + selected;
            FileInfo selectedSaveData = new FileInfo(selectedSave);

            if (File.Exists(selectedSave))
            {
                if (selectedSaveData.Length == SAVE_SIZE)
                {
                    _custom.loadSave(dsMainSave, selectedSave, "unusedParam");
                    success = true;
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
            return success;
        }

        public bool quickSaveClick()
        {
            getSaveDirRefs();

            bool success = false;

            if (isSaveDataValid())
            {
                _quick.doMySaveFuckYea(dsMainSave, DEFAULT_QUICKSAVE_NAME, dsQuickSaveDir);
                success = true;
            }
            else
            {
                MessageBox.Show("Save data is not valid", "Failed  quicksave");
            }
            return success;
        }

        public bool loadQuickSaveClick()
        {
            bool success = false;
            DirectoryInfo directory = new DirectoryInfo(dsQuickSaveDir);
            FileInfo[] files = directory.GetFiles();

            if (files.Length != 0)
            {

                _quick.loadSave(dsMainSave, files[0].Name, dsQuickSaveDir);
                setCurrentlyViewedDirectory(dsQuickSaveDir);
                success = true;
            }

            return success;
        }


        public void autoSaveClick()
        {
            getSaveDirRefs();
            _auto.doMySaveFuckYea("", "", "");
        }

        public void saveUserDirInRegistry()
        {
            string prompt = "Please enter your Dark souls game save directory." + Environment.NewLine +
                            Environment.NewLine
                            + "Your save directory should be something like: " + Environment.NewLine +
                            Environment.NewLine
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
                DialogResult tryAgain = MessageBox.Show("That was not a valid directory, try again?", "confirmation",
                    MessageBoxButtons.YesNo);
                userSaveDir = Microsoft.VisualBasic.Interaction.InputBox(prompt, title, userSaveDir, -1, -1);
            }

            RegKeyMgr.setRegistryKey(REGKEY_SAVEDIR, userSaveDir);
        }


        public void checkForSavePath()
        {

            userSaveDir = getUserSaveDir();
            //   userSaveDir = @"C:\Users\dann\AppData\Roaming\DarkSoulsII\0110000105e1a214\";
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

        public void getSaveDirRefs()
        {
            dsMainSave = "";
            dsQuickSave = "";
            userSaveDir = getUserSaveDir();
            dsMainSave = userSaveDir + DEFAULT_SAVE_NAME;
            dsQuickSave = userSaveDir + QUICK_SAVE_DIR + DEFAULT_QUICKSAVE_NAME;
            dsAutoSave = userSaveDir + AUTO_SAVE_DIR + DEFAULT_AUTOSAVE_NAME;

            currentlyViewedDirectory = RegKeyMgr.getRegKey(REGEKEY_LASTVIEWED);
            if (currentlyViewedDirectory == "")
            {
                currentlyViewedDirectory = userSaveDir;
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

        public void firstRun()
        {
            if (isSaveDataValid())
            {
                DialogResult setAnyways =
                    MessageBox.Show("Your save directory is already Valid. Set new save directory anyways?",
                        "confirmation",
                        MessageBoxButtons.YesNo);
                if (setAnyways == DialogResult.Yes)
                {
                    saveUserDirInRegistry();
                }
            }
        }

        public bool isSaveDataValid()
        {
            return File.Exists(dsMainSave);
        }

        public void setCurrentlyViewedDirectory(string currentDir)
        {
            currentlyViewedDirectory = currentDir;
            RegKeyMgr.setKey(REGEKEY_LASTVIEWED, currentlyViewedDirectory);
        }


        private void createDirIfNotExist(string dirName)
        {
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
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
    }
}