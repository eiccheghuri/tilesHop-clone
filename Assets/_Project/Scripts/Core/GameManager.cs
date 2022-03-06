using System;
using System.Collections;
using Custom_Debug_Log.Scripts;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Core
{
    public enum GameState
    {
        PreGame,
        Running,
        Paused,
        GameOver
    }
    
    
    [DefaultExecutionOrder(-1)]
    public class GameManager : MonoBehaviour
    {
        #region Singleton

        public static GameManager Instance;

        private void Awake()
        {
            if (Instance==null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion

        [Space] public GameState gameState;



        public Action GameStartAction;
        public Action GameOverAction;

        [Button]
        public void StartGame()
        {
            CustomDebug.Log("Game Started");
            GameStartAction?.Invoke();
            gameState = GameState.Running;
        }

        [Button]
        public void GameOver()
        {
           
            CustomDebug.Log("Game Over");
            GameOverAction?.Invoke();
            gameState = GameState.GameOver;
        }

        public void RestartGame()
        {
            StartCoroutine(SceneLoadCo());
        }

        private IEnumerator SceneLoadCo()
        {
            yield return new WaitForSeconds(0.1f);
            gameState = GameState.PreGame;
            SceneManager.LoadScene("Game");
        }




    }
}
