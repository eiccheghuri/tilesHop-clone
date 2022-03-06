using _Project.Scripts.Core;
using UnityEngine;

namespace _Project.Scripts.SwerveMovement
{
    [RequireComponent(typeof(SwerveMovementManager))]
    public class SwerveInputManager : MonoBehaviour
    {
        public float MoveFactorX => _moveFactorX;
        private float _moveFactorX;

        private SwerveMovementManager _swerveMovementManager;

        private void Awake()
        {
            _swerveMovementManager = GetComponent<SwerveMovementManager>();
        }

        private void Update()
        {
            MobileTouchInput();
        }


        private void MobileTouchInput()
        {
            if (GameManager.Instance.gameState==GameState.PreGame)
            {
                if (Input.touchCount==1)
                {
                    GameManager.Instance.StartGame();
                    return;
                }
            }

            if (GameManager.Instance.gameState == GameState.Running)
            {

                if (Input.touchCount == 1)
                {
                    var touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Moved)
                    {
                        var temp = touch.deltaPosition;
                        _moveFactorX = temp.x;
                        
                        _swerveMovementManager.MovePlayer(_moveFactorX);
                        
                    }
                    else if (touch.phase == TouchPhase.Stationary)
                    {
                        _moveFactorX = 0;
                    }
                    else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                    {
                        _moveFactorX = 0f;
                    }

                }
            }
            
        }

    }
}
