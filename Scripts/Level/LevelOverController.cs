using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Outscal.BasicUnity2DProject
{
    public class LevelOverController : MonoBehaviour
    {

        [SerializeField] private GameObject GameComplete;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                // Level is Over
                SoundManager.Instance.PlayMusic(Sounds.LevelCompleted);
                Debug.Log("Level finished by player");
                GameComplete.SetActive(true);
                LevelManager.Instance.MarkCurrentLevelComplete();
            }
        }
    }
}