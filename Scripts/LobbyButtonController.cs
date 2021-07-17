using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// On hitting of quit button it will show main menu.
/// </summary>
namespace Outscal.BasicUnity2DProject
{
    public class LobbyButtonController : MonoBehaviour
    {
        [Header("Button Settings")]
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
