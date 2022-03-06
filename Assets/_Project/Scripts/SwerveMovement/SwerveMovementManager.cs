using _Project.Scripts.Core;
using Custom_Debug_Log.Scripts;
using UnityEngine;

namespace _Project.Scripts.SwerveMovement
{
    public class SwerveMovementManager : MonoBehaviour
    {
        [Space] public float swerveSpeed;
        [Space] public float swerveBoundary;


        [Space] [SerializeField] private float screenWidth;


        private GameReferenceManager _gameReferenceManager;


        private void Awake()
        {
            screenWidth = Screen.width;
        }

        private void Start()
        {
            _gameReferenceManager = GameReferenceManager.Instance;
            GameManager.Instance.GameOverAction += OnGameOverResponse;
        }

        private void OnDisable()
        {
            GameManager.Instance.GameOverAction -= OnGameOverResponse;
        }

        public void MovePlayer(float inputValue)
        {
            if (GameManager.Instance.gameState == GameState.GameOver)
            {
                return;
            }
            
            inputValue = (inputValue * 100) / screenWidth;

            var rotX = inputValue * swerveSpeed / 18 * Mathf.Deg2Rad;

            var swerveAmount = Time.deltaTime * swerveSpeed * rotX;


            var targetPosition = new Vector3(swerveAmount, 0f, 0f);

            //Vector3.MoveTowards(_gameReferenceManager.playerTransform.position, targetPosition, Time.deltaTime * 1f);
            
            
            
            
            _gameReferenceManager.playerTransform.Translate(swerveAmount, 0f, 0f);

            _gameReferenceManager.playerTransform.position = new Vector2(
                Mathf.Clamp(_gameReferenceManager.playerTransform.position.x, -swerveBoundary, swerveBoundary),
                _gameReferenceManager.playerTransform.position.y);
        }


        private void OnGameOverResponse()
        {
            /*splineFollower.follow = false;
           _gameReferenceManager.playerDeathManager.DoDeathAnimation();*/
        }
    }
}