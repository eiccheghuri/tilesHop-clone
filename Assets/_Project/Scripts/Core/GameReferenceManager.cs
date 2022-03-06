using System;
using System.Collections.Generic;
using _Project.Scripts.Core.JumpPlatform;
using Doozy.Engine.UI;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Core
{
    public class GameReferenceManager : MonoBehaviour
    {

        #region Singleton

        public static GameReferenceManager Instance;

        private void Awake()
        {
            if (Instance==null)
            {
                Instance = this;
            }
        }

        #endregion

        [Title("Script References")]
        [Space] [Required] public ScoreManager scoreManager;
        [Space] [Required] public LevelManager levelManager;
        [Space] [Required] public PlatformPoolManager platformPoolManager;
        [Space] [Required] public SpawnManager spawnManager;
        [Space] [Required] public LaunchManager launchManager;
        
        [Title("Player References")]
        [Space] [Required] public Transform playerTransform;
        
        [Title("Ui References")]
        [Space] [Required] public TMP_Text scoreText;

        [Space] [Title("Score Level Variables")]
        public int scoreToNextLevel;
        [Space]
        public int currentScoreToNextLevel;

        
        [Title("Material References")] 
        [Required] [Space] public Material skyMaterial;
        [Required] [Space] public Material treeMaterial;
        [Required] [Space] public List<MeshRenderer> platformMeshRenders;
        [Required] [Space] public Material groundMaterial;
        
       
        
        [Title("Ui View Reference")]
        [Required] [Space] public UIView continueView;
        [Required] [Space] public UIView instructionView;

        private void Start()
        {
            currentScoreToNextLevel += scoreToNextLevel;
        }
    }
}
