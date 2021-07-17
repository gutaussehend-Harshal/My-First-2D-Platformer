using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// On the click of backButton it will show Lobby(Mainmenu).
/// </summary>
namespace Outscal.BasicUnity2DProject
{
    public class ButtonController : MonoBehaviour
    {
        [Header("Button Settings")]
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private GameObject levelSelection;

        void Start()
        {
            playButton.onClick.AddListener(buttonClick);
            quitButton.onClick.AddListener(quitGame);
        }

        void buttonClick()
        {
            SoundManager.Instance.Play(Sounds.buttonClick);
            levelSelection.SetActive(true);
            playButton.gameObject.SetActive(false);
            quitButton.gameObject.SetActive(false);
        }

        public void quitGame()
        {
            SoundManager.Instance.Play(Sounds.buttonClick);
            Application.Quit();
        }
    }
}
