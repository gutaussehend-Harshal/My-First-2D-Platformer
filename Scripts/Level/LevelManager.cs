﻿using UnityEngine;
using System;
using UnityEngine.SceneManagement;

/// <summary>
/// Set level status to complete.
/// </summary>
namespace Outscal.BasicUnity2DProject
{
    public class LevelManager : MonoBehaviour
    {
        [Header("LevelManager Settings")]
        private static LevelManager instance;
        [SerializeField] private string[] Levels;
        public static LevelManager Instance { get { return instance; } }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            if (GetLevelStatus(Levels[0]) == LevelStatus.Locked)
            {
                SetLevelStatus(Levels[0], LevelStatus.Unlocked);
            }
        }

        // Set level status to complete.
        public void MarkCurrentLevelComplete()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SetLevelStatus(currentScene.name, LevelStatus.Completed);
            int currentSceneIndex = Array.FindIndex(Levels, level => level == currentScene.name);
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex < Levels.Length)
            {
                SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
            }
        }

        public LevelStatus GetLevelStatus(string level)
        {
            LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
            return levelStatus;
        }

        public void SetLevelStatus(string level, LevelStatus levelStatus)
        {
            PlayerPrefs.SetInt(level, (int)levelStatus);
            Debug.Log("Setting level: " + level + " status: " + levelStatus);
        }
    }
}