using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Core.ObjectPool
{
    
    public class PoolAble : MonoBehaviour
    {
        
        [Required][GUIColor(1f,1f,0f)]
        [Space] public string poolAbleTag;
        
        private void OnDisable()
        {
            if (PoolManager.Instance)
            {
                PoolManager.Instance.ReturnGameObject(this);
            }
           
        }
        
        
    }
    
}
