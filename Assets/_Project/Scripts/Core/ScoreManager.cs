using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Core
{
    public class ScoreManager : MonoBehaviour
    {

        [Space] public int currentScore;
        
        private GameReferenceManager _gameReferenceManager;

        [Space] public bool canCount;

        private void Start()
        {
            _gameReferenceManager= GameReferenceManager.Instance;
        }

        [Button]
        public void IncreaseScore()
        {
           
                 currentScore++;

                if (currentScore==1 && !canCount)
                {
                    canCount = true;
                    currentScore = 0;
                    return;
                }
                
                UpdateScoreText();
                CheckForNextLevel();
            
           
        }

        private void UpdateScoreText()
        {
            _gameReferenceManager.scoreText.text = currentScore.ToString();
        }

        private void CheckForNextLevel()
        {
            if (currentScore>=_gameReferenceManager.currentScoreToNextLevel)
            {
                _gameReferenceManager.currentScoreToNextLevel += _gameReferenceManager.scoreToNextLevel;
                _gameReferenceManager.spawnManager.IncreaseLevel();
                _gameReferenceManager.levelManager.ChangeLevelColor();
              
            }
        }
    }
}
