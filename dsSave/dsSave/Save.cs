﻿using System;
using System.IO;
using System.Security;
using System.Windows.Forms;


namespace dsSave
{
    public abstract class Save
    {

         public abstract void doMySaveFuckYea(string selected, string defaultQuicksaveName, string dsQuickSaveDir);
         public abstract void loadSave(string dsMainSave, string fileToLoad, string dsQuickSaveDir);

     

    }
    
  }
