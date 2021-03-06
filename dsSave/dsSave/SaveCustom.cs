﻿using System.IO;
using System.Windows.Forms;

namespace dsSave
{
    public class SaveCustom : Save
    {
        public override void doMySaveFuckYea(string dsMainSave, string gameSaveName, string dsCustomSaveDir)
        {
            string dataToSave = dsCustomSaveDir + gameSaveName;

            if (File.Exists(dataToSave))
            {
                confirmOverwrite(dataToSave, gameSaveName, dsMainSave);
            }
            else
            {
                File.Copy(dsMainSave, dataToSave, true);
            }
        }
        
        public override void loadSave(string dsMainSave, string selectedSave, string notUsedHere)
        {
            //BACKUP
//            File.Copy(dsMainSave,
//                dsMainBackupSaveDir + DEFAULT_SAVE_NAME + "." + utils.getTimestamp(".dd_MMM_yyyy.hh;mm;sstt"), true);
            File.Copy(selectedSave, dsMainSave, true);
                
        }

        public void confirmOverwrite(string dataToSave, string gameSaveName, string dsMainSave)
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