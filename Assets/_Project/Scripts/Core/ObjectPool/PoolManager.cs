using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Core.ObjectPool
{
    public class PoolManager : MonoBehaviour
    {

        #region Singleton

        public static PoolManager Instance;

        private void Awake()
        {
            if (Instance==null)
            {
                Instance = this;
            }
        }
        

        #endregion
        
        
        [ShowInInspector][GUIColor(1f,1f,0f)]
        public Dictionary<string, Queue<GameObject>> ObjectPool = new Dictionary<string, Queue<GameObject>>();
        
        public GameObject GetObject(PoolAble poolAble)
        {
            if (ObjectPool.TryGetValue(poolAble.poolAbleTag,out Queue<GameObject> objectList))
            {
                if (objectList.Count==0)
                {
                    return CreateNewObject(poolAble);
                }
                else
                {
                    var temp = objectList.Dequeue();
                    return temp;
                }
            }
            else
            {
               return CreateNewPool(poolAble);
            }
        }

        private GameObject CreateNewObject(PoolAble poolAble)
        {
            var temp = Instantiate(poolAble.gameObject);
            return temp;
        }

        private GameObject CreateNewPool(PoolAble poolAble)
        {
            var temp = Instantiate(poolAble.gameObject);
            return temp;
        }

        public void ReturnGameObject(PoolAble poolAble)
        {
            if (ObjectPool.TryGetValue(poolAble.poolAbleTag,out Queue<GameObject> objectList))
            {
                objectList.Enqueue(poolAble.gameObject);
            }
            else
            {
                Queue<GameObject> newObjectQueue = new Queue<GameObject>();
                newObjectQueue.Enqueue(poolAble.gameObject);
                ObjectPool.Add(poolAble.poolAbleTag,newObjectQueue);
            }
            poolAble.gameObject.SetActive(false);
        }
        

    }
}
