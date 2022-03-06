using System;
using _Project.Scripts.Core;
using Custom_Debug_Log.Scripts;
using UnityEngine;

namespace _Project.Scripts.Ground
{
    public class Ground : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                /*CustomDebug.Log("Game Over");*/
                if (GameManager.Instance.gameState==GameState.Running)
                {
                    CustomDebug.Log("Game Over");
                }
                
            }
        }
    }
}
