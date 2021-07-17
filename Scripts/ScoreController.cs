using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// After hitting key the score will be increased and it will show on the screen.
/// </summary>
namespace Outscal.BasicUnity2DProject
{
    public class ScoreController : MonoBehaviour
    {
        [Header("Score Settings")]
        private TextMeshProUGUI scoreText;
        private int score = 0;

        private void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            RefreshUI();
        }

        // To increase the score
        public void IncreaseScore(int increment)
        {
            score += increment;
            RefreshUI();
        }

        // To show the score
        public void RefreshUI()
        {
            scoreText.text = "Score: " + score;
        }
    }
}