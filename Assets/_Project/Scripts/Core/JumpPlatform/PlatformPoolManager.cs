using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Core.JumpPlatform
{
    public class PlatformPoolManager : MonoBehaviour
    {
        [Space] public List<GameObject> platforms;
        [Space] public int numberOfPlatform;
        [Space] public GameObject platform;

        private GameReferenceManager _gameReferenceManager;

        private void Awake()
        {
            platforms = new List<GameObject>();
        }

        private void Start()
        {
            _gameReferenceManager= GameReferenceManager.Instance;
            GeneratePlatforms();
        }

        private void GeneratePlatforms()
        {
            for (int i = 0; i < numberOfPlatform; i++)
            {
                var tempObject = Instantiate(platform);
                tempObject.SetActive(false);
                platforms.Add(tempObject);

               // var platformScript = platform.GetComponent<JumpPlatform>();
                
               // _gameReferenceManager.platformMeshRenders.Add(platformScript.platformMeshRenderer);
                
            }
        }

        public GameObject GetPlatform()
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                if (!platforms[i].gameObject.activeSelf)
                {
                    return platforms[i].gameObject;
                }
            }

            return null;
        }
        
        
    }
}
