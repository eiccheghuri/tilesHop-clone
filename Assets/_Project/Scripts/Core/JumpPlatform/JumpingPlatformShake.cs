using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Core.JumpPlatform
{
    public class JumpingPlatformShake : MonoBehaviour
    {
        [Title("Jumping Platform Ball Collision Variables")] 
        [Space] [SerializeField] private float shakePositionDuration;
        [Space] [SerializeField] private Vector3 targetShakePosition;
        [Space] [SerializeField] private int shakeVibrato;
        [Space] [SerializeField] private float shakeRandomness;
        [Space] [SerializeField] private Ease shakeEase;

        [Button]
        private void ShakePosition()
        {
           
            transform.DOShakePosition(shakePositionDuration, targetShakePosition, shakeVibrato, shakeRandomness).SetEase(shakeEase);
        }
    }
}
