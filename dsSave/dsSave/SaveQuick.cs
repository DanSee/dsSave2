using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace dsSave
{
    public class SaveQuick : Save
    {

        public override void doMySaveFuckYea(string dsMainSave, string DEFAULT_QUICKSAVE_NAME, string dsQuickSaveDir)
        {
                string newSaveName = dsQuickSaveDir + "." + DEFAULT_QUICKSAVE_NAME +
                                     Utils.getTimestamp(".dd_MMM_yyyy.hh-mm.sstt");
                File.Copy(dsMainSave, newSaveName);
        }


        public override void loadSave(string dsMainSave, string fileToLoad, string dsQuickSaveDir)
        {
            //BACKUP    
              //   File.Copy(dsMainSave, gameToSave + "." + getTimestamp(".dd_MMM_yyyy.hh;mm;sstt"), true);
                File.Copy(dsQuickSaveDir + fileToLoad, dsMainSave, true);
            }
    }
}