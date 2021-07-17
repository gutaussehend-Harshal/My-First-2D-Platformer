using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Once player reached end point of level it will show level complete screen.
/// </summary>
namespace Outscal.BasicUnity2DProject
{
    public class LevelOverController : MonoBehaviour
    {
        [Header("GameComplete Settings")]
        [SerializeField] private GameObject gameComplete;

        // Level is Over
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                SoundManager.Instance.PlayMusic(Sounds.LevelCompleted);
                Debug.Log("Level finished by player");
                gameComplete.SetActive(true);
                LevelManager.Instance.MarkCurrentLevelComplete();
            }
        }
    }
}