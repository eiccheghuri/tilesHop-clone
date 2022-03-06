using System;
using _Project.Scripts.Core;
using Custom_Debug_Log.Scripts;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerPlatformDetector : MonoBehaviour
    {
        private GameReferenceManager _gameReferenceManager;

        private void Start()
        {
            _gameReferenceManager= GameReferenceManager.Instance;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("platform"))
            {
                CustomDebug.Log("Platform detected");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("platform"))
            {
                CustomDebug.Log("Platform Exit");
            }
        }
    }
}
