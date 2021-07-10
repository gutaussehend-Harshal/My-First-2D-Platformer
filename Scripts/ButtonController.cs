using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Outscal.BasicUnity2DProject
{
    public class ButtonController : MonoBehaviour
    {
        [SerializeField] private Button Backbutton;
        [SerializeField] private GameObject LevelSeletion;
        void Start()
        {
            Backbutton.onClick.AddListener(ButtonClick);
        }
        void ButtonClick()
        {
            SoundManager.Instance.Play(Sounds.ButtonClick);
            LevelSeletion.SetActive(true);
            Backbutton.gameObject.SetActive(false);
        }
    }
}
