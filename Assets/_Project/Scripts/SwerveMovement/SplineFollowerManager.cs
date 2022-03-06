using _Project.Scripts.Core;
using UnityEngine;

namespace _Project.Scripts.SwerveMovement
{
    public class SplineFollowerManager : MonoBehaviour
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

        private void OnGameStartResponse()
        {
           // _gameReferenceManager.splineFollower.follow = true;
        }
      

       
    }
}
