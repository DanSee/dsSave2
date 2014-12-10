using System;
using System.IO;
using System.Windows.Forms;

namespace dsSave
{
    public class RealSaveManager
    {

        public Save _auto = new SaveAuto();
        public Save _custom = new SaveCustom();
        public Save _quick = new SaveQuick();

        public void customSaveClick()
        {
            getSaveDirRefs();
            _custom.doMySaveFuckYea("Fuck this needs to be user input");
        }
        public void autoSaveClick()
        {
            getSaveDirRefs();
            _auto.doMySaveFuckYea("");
        }
        public void quickSaveClick()
        {
            getSaveDirRefs();
            _quick.doMySaveFuckYea("");
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

            RegKeyMgr.setRegistryKey(REGKEY_SAVEDIR, userSaveDir);
        }



        public const string DEFAULT_SAVE_NAME = @"DARKSII0000.sl2";
        public const string MAINBACKUP_SAVE_DIR = @"_MainSaveFileBackups\";

        public string dsMainBackupSaveDir;
        public string dsMainSave;

        //Fuck everyting needs to share these also.  Kind of. 
        /// ///////////////////////////////////////
        public const long SAVE_SIZE = 4330480;
        public string currentlyViewedDirectory;
        public string userSaveDir;
        public string dsQuickSave;
        public string dsAutoSave;
        public const string REGKEY_SAVEDIR = "UserSaveDir";
        public const string REGEKEY_LASTVIEWED = "LastViewedDir";
        public const string DEFAULT_QUICKSAVE_NAME = @"quickSave";
        public const string QUICK_SAVE_DIR = @"_quickSaveGames\";
        public const string CUSTOM_SAVE_DIR = @"_customSaveGames\";
        public string dsCustomSaveDir;
        public string dsAutoSaveDir;
        public string dsQuickSaveDir;
        private const string AUTO_SAVE_DIR = @"_autoSaveGames\";
        private const string DEFAULT_AUTOSAVE_NAME = @"autoSave";


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