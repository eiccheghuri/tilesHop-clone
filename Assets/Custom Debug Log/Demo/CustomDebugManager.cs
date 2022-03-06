using Custom_Debug_Log.Scripts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts
{
    public class CustomDebugManager : MonoBehaviour
    {

        [Button]
        private void ShowNormalDebug()
        {
            CustomDebug.Log("something");
            
        }

        [Button]
        private void ShowDebugWarning()
        {
            CustomDebug.LogWarning("something");
        }

        [Button]
        private void ShowDebugError()
        {
            CustomDebug.LogError("something");
        }
    
    }
}
