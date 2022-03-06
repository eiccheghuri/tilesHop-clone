using System;
using _Project.Scripts.Core;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerManager : MonoBehaviour
    {
        
        private GameReferenceManager _gameReferenceManager;
      

        private float startHeight;

        private void Start()
        {
            _gameReferenceManager= GameReferenceManager.Instance;
            startHeight = transform.position.y;
        }
        private void OnTriggerEnter(Collider other)
        {
            
            if (other.gameObject.CompareTag("platform"))
            {
                IncreaseScore();
            }
        }
        
        private void IncreaseScore()
        {
            _gameReferenceManager.scoreManager.IncreaseScore();
        }
    }
}
