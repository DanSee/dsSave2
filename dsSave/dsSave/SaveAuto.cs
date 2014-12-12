namespace dsSave
{




    public class SaveAuto : Save
    {

        private const string AUTO_SAVE_DIR = @"_autoSaveGames\";
        private const string DEFAULT_AUTOSAVE_NAME = @"autoSave";
        public string dsAutoSaveDir;

   
        public override void doMySaveFuckYea(string selected, string defaultQuicksaveName, string dsQuickSaveDir)
        {
            throw new System.NotImplementedException();
        }

        public override void loadSave(string dsMainSave, string fileToLoad, string dsQuickSaveDir)
        {
            throw new System.NotImplementedException();
        }

    
    }
}