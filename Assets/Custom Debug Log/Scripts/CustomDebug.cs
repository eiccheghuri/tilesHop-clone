using UnityEngine;

namespace Custom_Debug_Log.Scripts
{
    public static class CustomDebug
    {
        private static CustomDebugSettings _sCustomDebugSettings;
        
        [RuntimeInitializeOnLoadMethod]
        static void LoadSettings()
        {
            _sCustomDebugSettings = Resources.Load<CustomDebugSettings>("Custom Debug Log/Custom Debug Settings");
            
            if (!_sCustomDebugSettings)
            {
                Debug.LogError("Custom Debug Log Settings Not Found. Please Ensure That, The Resource Path Is Correct");
            }
        }

        public static void Log(string message)
        {
            if (!_sCustomDebugSettings)
            {
                Debug.LogError("Custom Debug Log Settings Not Found. Please Ensure That, The Resource Path Is Correct");
                return;
            }
            
            if (_sCustomDebugSettings.showLog)
            {
               // Debug.Log("<color=yellow:b>"+message+"</color>");
               // Debug.Log("<color=green:b>"+message+"</color>");
                Debug.Log(message % CustomDebugColorize.Green % CustomDebugFontFormat.Bold );
                // Debug.Log(s_customDebugSettings.debugColor+message+"</color>");
            }
        }
        
        
        public static void LogWarning(string message)
        {
            if (!_sCustomDebugSettings)
            {
                Debug.LogError("Custom Debug Log Settings Not Found. Please Ensure That, The Resource Path Is Correct");
                return;
            }

            if (_sCustomDebugSettings.showLog)
            {
                Debug.Log(message % CustomDebugColorize.Yellow % CustomDebugFontFormat.Bold );
            }
        }

        public static void LogError(string message)
        {
            if (!_sCustomDebugSettings)
            {
                Debug.LogError("Custom Debug Log Settings Not Found. Please Ensure That, The Resource Path Is Correct");
                return;
            }

            if (_sCustomDebugSettings.showLog)
            {
                Debug.LogError(message % CustomDebugColorize.Red % CustomDebugFontFormat.Bold % CustomDebugFontFormat.Italic);
            }
        }
    }
}
