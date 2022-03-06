using System;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace _Project.Scripts.Core
{
    public class UiManager : MonoBehaviour
    {

        private GameReferenceManager _gameReferenceManager;

        private void Start()
        {
            _gameReferenceManager= GameReferenceManager.Instance;

            GameManager.Instance.GameStartAction += OnGameStartResponse;
        }

        private void OnDisable()
        {
            GameManager.Instance.GameStartAction -= OnGameStartResponse;
        }

        public void OnContinueButtonClicked()
        {
            _gameReferenceManager.continueView.Hide();
            GameManager.Instance.RestartGame();
        }

        private void OnGameStartResponse()
        {
            _gameReferenceManager.instructionView.Hide();
        }
        
        
    }
}
