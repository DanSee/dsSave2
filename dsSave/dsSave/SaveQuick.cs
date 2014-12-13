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

            int numberPart = 0;
            string namePart;

            DirectoryInfo directory = new DirectoryInfo(dsQuickSaveDir);
            FileInfo[] files = directory.GetFiles();
            if (files.Length != 0)
            {
                foreach (FileInfo f in files)
                {
                    numberPart = Int16.Parse(f.Name.Substring(0, 2));
                    namePart = f.Name.Substring(2);

                    if (numberPart == 50)
                    {
                        File.Delete(dsQuickSaveDir + f.Name);
                    }
                    else
                    {
                        numberPart += 1;
                        string oldfile = dsQuickSaveDir + f.Name;
                        string newfile = dsQuickSaveDir + numberPart.ToString("D2") + namePart ;
                        File.Move(oldfile, newfile ); 
                    }
                }
            }
            
            string newSaveName = dsQuickSaveDir +  "01." + DEFAULT_QUICKSAVE_NAME +
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