using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button Backbutton;
    public GameObject LevelSeletion;
    void Start()
    {
        Backbutton.onClick.AddListener(ButtonClick);
    }
    void ButtonClick()
    {
        // SceneManager.LoadScene("Level1");
        LevelSeletion.SetActive(true);
        Backbutton.gameObject.SetActive(false);
    }
}
