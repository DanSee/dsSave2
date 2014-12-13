using System;
using Microsoft.Win32;

namespace dsSave
{
    class RegKeyMgr
    {
        const string USER_ROOT = "HKEY_CURRENT_USER";
        const string SUBKEY = "dsSave2";
        const string KEYNAME = USER_ROOT + "\\" + SUBKEY;

        public static void setKey(string stringKeyName, string keyValue)
        {
            Registry.SetValue(KEYNAME, stringKeyName, keyValue);
        }      
        
//        public static void setKey(string keyValue, stringKeyName)
//        {
//            Registry.SetValue(KEYNAME, "UserSaveDir", keyValue);
//        }   
//        
//        public static void setLastViewedDir(string keyValue)
//        {
//            Registry.SetValue(KEYNAME, "lastViewedDir", keyValue);
//        }

        public static string getRegKey(string keyNodeName)
        {
            return (string)Registry.GetValue(KEYNAME, keyNodeName, "");
        }


        public static void setRegistryKey(string valueName, string keyValue)
        {
            try
            {
                setKey(valueName, keyValue);
            }
            catch (Exception ee)
            {}
        }
    
    }
}
