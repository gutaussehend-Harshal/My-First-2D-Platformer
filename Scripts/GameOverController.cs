using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Outscal.BasicUnity2DProject
{

    public class GameOverController : MonoBehaviour
    {
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