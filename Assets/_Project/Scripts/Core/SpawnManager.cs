using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Core.JumpPlatform;
using _Project.Scripts.Core.ObjectPool;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Core
{
    public class SpawnManager : MonoBehaviour
    {
        [Required]
        [SerializeField] [Space] public PoolAble jumpingPlatformPoolAble;
        [Space] [SerializeField] private List<Transform> spawnPosition;

        [Space] [SerializeField] private float spawnPositionOffsetX;

        [Space] public float platformMoveDuration;
        [Space] [SerializeField] private float moveIncreaseOffset;
        [Space] [SerializeField] private float minimumPlatformSpeed;

        [Space(10)] [SerializeField] private float startWait;
        [Space()] [SerializeField] private float spawnWait;
        [Space()] [SerializeField] private float spawnWaitMin;
        [Space()] [SerializeField] private float spawnWaitMax;


        private GameReferenceManager _gameReferenceManager;
        private bool _isStartTile=true;

       

        private void Start()
        {
            _gameReferenceManager= GameReferenceManager.Instance;
            GameManager.Instance.GameStartAction+=OnGameStartResponse;
            
        }

        private void OnDisable()
        {
            GameManager.Instance.GameStartAction-=OnGameStartResponse;
        }

        private void OnGameStartResponse()
        {
           // StartSpawningTile();
        }


        [Button]
        public void StartSpawningTile()
        {
          //  InvokeRepeating(nameof(SpawnTile),1f,.5f);

          StartCoroutine(nameof(StartSpawnTileCo));
        }

        private IEnumerator StartSpawnTileCo()
        {
            if (_isStartTile)
            {
                 SpawnTile();
                _isStartTile = false;
            }
            
            //yield return new WaitForSeconds(spawnWait);
            yield return new WaitForSeconds(GetRandomSpawnWait());
            SpawnTile();
            if (GameManager.Instance.gameState!=GameState.GameOver)
            {
                StartCoroutine(nameof(StartSpawnTileCo));
            }
        }
        

        [Button]
        private void SpawnTile()
        {
            var tempObject = _gameReferenceManager.platformPoolManager.GetPlatform();
            tempObject.transform.position = GetTransform();
            tempObject.SetActive(true);
            var platformScript = tempObject.GetComponent<JumpPlatform.JumpPlatform>();
            platformScript.moveDuration = platformMoveDuration;
            platformScript.MovePlatform();
            platformScript.platformMeshRenderer.material =
                _gameReferenceManager.levelManager.currentLevelColor.runningPlatformColor;

            if (_gameReferenceManager.launchManager.targetJumpPlatform==null)
            {
                _gameReferenceManager.launchManager.targetJumpPlatform = platformScript;
            }
            _gameReferenceManager.launchManager.allJumpPlatforms.Add(platformScript);
            

        }

        private Vector3 GetTransform()
        {
            /*Transform spawnTransform;
            var randomIndex = Random.Range(0, spawnPosition.Count);
            spawnTransform= spawnPosition[randomIndex];
            return spawnTransform.position;*/

            var randomXvalue = Random.Range(-spawnPositionOffsetX, spawnPositionOffsetX);

            var randomPosition = new Vector3(randomXvalue, spawnPosition[0].position.y, spawnPosition[0].position.z);

            return randomPosition;
            

        }

        public void IncreaseLevel()
        {
            if (platformMoveDuration<=minimumPlatformSpeed)
            {
                return;
            }
            
            platformMoveDuration -= moveIncreaseOffset;
            
        }

        private float GetRandomSpawnWait()
        {
            var randomValue = Random.Range(spawnWaitMin, spawnWaitMax);
            return randomValue;
        }
        
        


    }
}
