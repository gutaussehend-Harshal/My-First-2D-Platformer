using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyButtonController : MonoBehaviour
{
    public Button Quitbutton;
    void Start()
    {
        Quitbutton.onClick.AddListener(ButtonClick);
    }
    void ButtonClick()
    {
        SceneManager.LoadScene("Lobby");
    }
}
