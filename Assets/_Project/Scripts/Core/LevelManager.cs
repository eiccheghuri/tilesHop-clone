using System;
using _Project.Scripts.Color;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Core
{
    public class LevelManager : MonoBehaviour
    {
        [InlineEditor()]
        [Space] [SerializeField] private LevelColorSo levelColorSo;


        private GameReferenceManager _gameReferenceManager;
        [Space]
        public PowerUpColor currentLevelColor;

        private void Start()
        {
            _gameReferenceManager= GameReferenceManager.Instance;
            
            ChangeLevelColor();
        }


        [Button]
        public void ChangeLevelColor()
        {
            var levelColor = GetLevelColor();
            SetLevelColor(levelColor);
            currentLevelColor = levelColor;

        }

        private PowerUpColor GetLevelColor()
        {
            var levelColorIndex = Random.Range(0, levelColorSo.levelColors.Count);
            return levelColorSo.levelColors[levelColorIndex];
        }


        private void SetLevelColor(PowerUpColor _powerUpColor)
        {
            _gameReferenceManager.skyMaterial.SetColor("_ColorHigh",_powerUpColor.skyColor);
            _gameReferenceManager.treeMaterial.SetColor("_ColorHigh",_powerUpColor.treeColor);
            _gameReferenceManager.groundMaterial.SetColor("_ColorLow",_powerUpColor.groundMaterial);

            for (int i = 0; i <  _gameReferenceManager.platformMeshRenders.Count; i++)
            {
                _gameReferenceManager.platformMeshRenders[i].material = _powerUpColor.runningPlatformColor;
            }
        }
    }
}
