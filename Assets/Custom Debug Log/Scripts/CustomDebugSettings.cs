using Sirenix.OdinInspector;
using UnityEngine;

namespace Custom_Debug_Log.Scripts
{
    [CreateAssetMenu(fileName = "Custom Debug Settings", menuName = "Custom Debug Settings")]
    public class CustomDebugSettings : ScriptableObject
    {
        [Space][GUIColor(1f,1f,0f)]
        public bool showLog;
        
    }
}
