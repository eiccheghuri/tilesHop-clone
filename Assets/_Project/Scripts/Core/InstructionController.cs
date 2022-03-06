using System;
using _Project.Scripts.Core;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _project.Scripts.Core
{
    public class InstructionController : MonoBehaviour
    {
        [Space] [GUIColor(1f, 1f, 0f)] public RectTransform target;
        [GUIColor(1f, 1f, 0f)][Space] public float animationDuration;
        [GUIColor(1f, 1f, 0f)][Space] public Ease easeType;
        [GUIColor(1f, 1f, 0f)][Space] public int loopNumber;
        [GUIColor(1f, 1f, 0f)][Space] public LoopType loopType;
        [GUIColor(1f, 1f, 0f)][Space] public float targetPosition;

        private void Start()
        {
            DoInstructionAnimation();
            
            GameManager.Instance.GameStartAction += DeactivateInstruction;
        }

        private void OnDisable()
        {
            GameManager.Instance.GameStartAction -= DeactivateInstruction;
        }

        [Button]
        public void DoInstructionAnimation()
        {
            target.gameObject.SetActive(true);
            target.DOAnchorPosX(-targetPosition,
                animationDuration).SetEase(easeType).SetLoops(loopNumber, loopType);
        }

        public void DeactivateInstruction()
        {
            if (target.gameObject.activeSelf)
            {
                DOTween.Kill(target);
                target.gameObject.SetActive(false);
            }
           
        }
    }
}