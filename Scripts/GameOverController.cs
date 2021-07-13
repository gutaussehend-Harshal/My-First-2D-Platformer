using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// After player is died then on hitting of restart button it will load level-1.
/// </summary>
namespace Outscal.BasicUnity2DProject
{
    public class GameOverController : MonoBehaviour
    {
        [Header("Button Settings")]
        [SerializeField] private Button buttonRestart;

        private void Awake()
        {
            buttonRestart.onClick.AddListener(ReloadLevel);
        }

        public void PlayerDied()
        {
            SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
            gameObject.SetActive(true);
        }

        public void ReloadLevel()
        {
            SceneManager.LoadScene("Level1");
        }
    }
}