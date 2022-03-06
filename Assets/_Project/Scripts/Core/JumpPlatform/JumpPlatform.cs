using System;
using _Project.Scripts.Core.ObjectPool;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Core.JumpPlatform
{
    public enum PlatformType
    {
        StartPlatform,
        NormalPlatform
        
    }
    
    
    
    public class JumpPlatform : MonoBehaviour
    {
        [Title("Move Variables")]
        [Space] [SerializeField] private float targetValueZ;
        [Space]  public float moveDuration;
        [Space] [SerializeField] private Ease moveEase;

        [Space] [SerializeField] private float moveIncreaseOffset;

        [Space] [SerializeField] private PlatformType platformType;

        [Space] public float platformVelocity;
        [Space] public float startValueZ;

        [Space] public MeshRenderer platformMeshRenderer;

        [Title("Jumping Platform Ball Collision Variables")] 
        [Space] [SerializeField] private float shakePositionDuration;
        [Space] [SerializeField] private Vector3 targetShakePosition;
        [Space] [SerializeField] private int shakeVibrato;
        [Space] [SerializeField] private float shakeRandomness;
        [Space] [SerializeField] private Ease shakeEase;
       

        [SerializeField]
        private PoolAble poolAble;

        private Tween moveTween;

        private void Start()
        {
            if (platformType==PlatformType.StartPlatform)
            {
                moveDuration = 1;
            }

            //moveDuration=
            startValueZ = transform.position.z;
        }

        [Button]
        public void MovePlatform()
        {
            startValueZ = transform.position.z;
            CalculateVelocity();
            moveTween= transform.DOMoveZ(targetValueZ, moveDuration).SetEase(moveEase).SetUpdate(UpdateType.Fixed).OnComplete(DisableGameObject);
        }

        [Button]
        public void IncreaseMovementSpeed()
        {
            moveDuration -= moveIncreaseOffset;
        }

        private void DisableGameObject()
        {
            moveTween.Kill();
           gameObject.SetActive(false);
        }

        private void CalculateVelocity()
        {
            var totalDistance = Mathf.Abs(targetValueZ - startValueZ);
            moveDuration = totalDistance / 10f;
            platformVelocity = totalDistance / moveDuration;
        }

        public void StopAnimation()
        {
            moveTween.Kill();
        }
        
        public void ShakePosition()
        {
            transform.DOShakeScale(shakePositionDuration, targetShakePosition, shakeVibrato, shakeRandomness).SetEase(shakeEase);
        }
        
        
    }
}
