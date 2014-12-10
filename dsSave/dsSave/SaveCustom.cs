



using System.IO;

namespace dsSave
{

    public class SaveCustom : Save
    {


        public override void doMySaveFuckYea(string selected)
        {
            string selectedSave = currentlyViewedDirectory + selected;
            FileInfo selectedSaveData = new FileInfo(selectedSave);

            if (File.Exists(selectedSave))
            {
                if (selectedSaveData.Length == SAVE_SIZE)
                {
                    File.Copy(dsMainSave,
                        dsMainBackupSaveDir + DEFAULT_SAVE_NAME + "." + getTimestamp(".dd_MMM_yyyy.hh;mm;sstt"), true);
                    File.Copy(selectedSave, dsMainSave, true);
//                    printLabel("Loaded: " + selected, "Loaded custom");
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

        public void Click(string gameSaveName)
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
//                printLabel("Saved " + gameSaveName, "Saved custom");
            }
            else
            {
                MessageBox.Show("The main save data is missing.");
//                printLabel("Save data missing", "Failed custom save");
            }
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

      
    
    }

}