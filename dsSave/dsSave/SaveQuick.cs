using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace dsSave
{
    public class SaveQuick : Save
    {
      
        public string dsQuickSaveDir;

        public override void doMySaveFuckYea(string selected)
        {
            if (isSaveDataValid())
            {
                string highestNumber = getHighestSaveNumber(true);
                string newSaveName = dsQuickSaveDir + highestNumber + "." + DEFAULT_QUICKSAVE_NAME +
                                     getTimestamp(".dd_MMM_yyyy.hh-mm.sstt");
                File.Copy(dsMainSave, newSaveName);
                //printLabel("QuickSave", "Quicksave");
            }
            else
            {
                MessageBox.Show("Save data is not valid", "Failed  quicksave");
            }
        }

        public void loadQuick()
        {
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
                    if (isValidNumber && currSaveNum == currentNumber)
                    {
                        fileToLoad = f.Name;
                    }
                }

                File.Copy(dsMainSave, dsMainBackupSaveDir + DEFAULT_SAVE_NAME + "." + getTimestamp(".dd_MMM_yyyy.hh;mm;sstt"), true);
                File.Copy(dsQuickSaveDir + fileToLoad, dsMainSave, true);
                setCurrentlyViewedDirectory(dsQuickSaveDir);
                //printLabel("Loaded most recent Quicksave", "Quicksave loaded");
            }
            else
            {
                //printLabel("There is no quicksave file to load!", "Failed loading quicksave");
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
    }
}