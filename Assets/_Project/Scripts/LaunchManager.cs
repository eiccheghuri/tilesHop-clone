using System;
using System.Collections.Generic;
using System.Diagnostics;
using _Project.Scripts.Core;
using _Project.Scripts.Core.JumpPlatform;
using Custom_Debug_Log.Scripts;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace _Project.Scripts
{
    public class LaunchManager : MonoBehaviour
    {
        
        [Title("Jumping Variables")]
        [Space] public float startHeight;
        [Space] public float initJumpHeight;
        [Space] public float calculatedJumpHeight;
        [Space] public float jumpDuration;
        [Space] public Ease moveEaseUp;
        [Space] public Ease moveEaseDown;

        [Space(10)] public float jumpHeightIncrementPercent;
       
        [Space] public float uptime;
        [Space] public float downtime;
        [Space] public float upTimePercent;
        [Space] public JumpPlatform targetJumpPlatform;

        [Space] public List<JumpPlatform> allJumpPlatforms;
        [Space] public List<JumpPlatform> startJumpPlatforms;
        [Space] public bool isStartPlatformFinished;

        [Space] public float timeOffset;

        [Title("Ground Check Variables")]
        [Space] public float rayDistance;
        [Space] public LayerMask platformLayerMask;

        [GUIColor(1f,1f,0f)]
        [Space][SerializeField]
        private int index=0;
        
        private Rigidbody playerRb;

        private GameReferenceManager _gameReferenceManger;
        
        private void Awake()
        {
            allJumpPlatforms = new List<JumpPlatform>();
            playerRb = GetComponent<Rigidbody>();
        }
        
        private void Start()
        {
            startHeight = transform.position.y;
            targetJumpPlatform = startJumpPlatforms[index];
           GameManager.Instance.GameStartAction += OnGameStartResponse;
           _gameReferenceManger= GameReferenceManager.Instance;
        }

        private void OnDisable()
        {
            GameManager.Instance.GameStartAction -= OnGameStartResponse;
        }


        private void OnGameStartResponse()
        {
            
            StartInitialMovingPlatformAnimation();
           // Invoke(nameof(BallJump),1.5f);
            BallJump();
        }

       
        public void BallJumpY()
        {

            PunchScaleAnimation();
            transform.DOMoveY(calculatedJumpHeight, uptime-timeOffset).SetEase(moveEaseUp).SetUpdate(UpdateType.Fixed).OnComplete(() =>
            {
              
                transform.DOMoveY(startHeight, downtime-timeOffset).SetEase(moveEaseDown).SetUpdate(UpdateType.Fixed).OnComplete(
                    () =>
                    {
                       
                        if (CheckGround())
                        {
                            targetJumpPlatform.ShakePosition();

                            if (!isStartPlatformFinished)
                            {
                                if (index<startJumpPlatforms.Count)
                                {
                                    targetJumpPlatform = startJumpPlatforms[index++];
                                    BallJump();
                                    
                                    if (index==1)
                                    {
                                        _gameReferenceManger.spawnManager.StartSpawningTile();
                                    }
                                }
                                else
                                {
                                    isStartPlatformFinished = true;
                                    index = 0;
                                    BallJump();
                                   
                                }
                            }
                            else
                            {
                                if (index<allJumpPlatforms.Count)
                                {
                                    targetJumpPlatform = allJumpPlatforms[index++];
                                    BallJump();
                                }
                            }
                            
                           
                        }

                    });
            });
            

        }

       
        private void PunchScaleAnimation()
        {
            transform.DOPunchScale(new Vector3(0.05f, 0.05f, 0.05f), 0.5f, 10,1f);
        }
        
       
        

       
        private void JumpTimeDistribution()
        {
            uptime = (upTimePercent * jumpDuration) / 100f;
            downtime = jumpDuration - uptime;
        }

        [Button(ButtonSizes.Medium)]
        private void BallJump()
        {
           // StartAnimation();
            //targetJumpPlatform.MovePlatform();

            
           
           
            CalculateJumpVariables();
            BallJumpY();
        }

        private void CalculateJumpVariables()
        {
            var distance = Mathf.Abs(targetJumpPlatform.transform.position.z - transform.position.z);
            jumpDuration = distance / targetJumpPlatform.platformVelocity;
            JumpTimeDistribution();

            if (distance>3f)
            {
                calculatedJumpHeight = initJumpHeight + ((distance * jumpHeightIncrementPercent) / 100f);
            }
            else
            {
                calculatedJumpHeight = initJumpHeight;
            }

        }

        private void StartInitialMovingPlatformAnimation()
        {
            for (int i = 0; i < startJumpPlatforms.Count; i++)
            {
                startJumpPlatforms[i].MovePlatform();
            }
        }

        private bool CheckGround()
        {
            
          // Physics.Raycast(groundCheckTransform.position, Vector3.down, rayDistance);

         // RaycastHit raycastHit;
            
            if (!Physics.Raycast(transform.position, Vector3.down, rayDistance,platformLayerMask ))
            {
                playerRb.useGravity = true;
                playerRb.isKinematic = false;
                GameManager.Instance.GameOver();
                _gameReferenceManger.continueView.Show();
               return false;
            }

            return true;
        }

        
        
    }
}
