using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Color
{
    
    [CreateAssetMenu(fileName = "Level Info",menuName = "ScriptableObjects/LevelInformation")]
    public class LevelColorSo : ScriptableObject
    {
        public List<PowerUpColor> levelColors;
    }

    [Serializable]
    public class PowerUpColor
    {
        public UnityEngine.Color skyColor;
        public UnityEngine.Color treeColor;
        [InlineEditor(InlineEditorModes.SmallPreview)]
        public Material runningPlatformColor;
        public UnityEngine.Color groundMaterial;
    }
}
