using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Outscal.BasicUnity2DProject
{
    public class LobbyButtonController : MonoBehaviour
    {
        [SerializeField] private Button Quitbutton;
        void Start()
        {
            Quitbutton.onClick.AddListener(ButtonClick);
        }
        void ButtonClick()
        {
            SceneManager.LoadScene("Lobby");
        }
    }
}
