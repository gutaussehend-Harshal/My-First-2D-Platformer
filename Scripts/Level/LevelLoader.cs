using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// On hitting on different level buttons, levels will not unlock until previous level is completed.
/// It will open level irrespective of button clicked.
/// </summary>
namespace Outscal.BasicUnity2DProject
{
    [RequireComponent(typeof(Button))]
    public class LevelLoader : MonoBehaviour
    {
        [Header("LevelLoader Settings")]
        private Button button;
        [SerializeField] private string LevelName;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(onClick);
        }

        // On hitting on different level buttons, levels will not unlock until previous level is completed.It will open level irrespective of button clicked.
        private void onClick()
        {
            LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
            switch (levelStatus)
            {
                case LevelStatus.Locked:
                    Debug.Log("Can't play this level till you unlock it");
                    break;

                case LevelStatus.Unlocked:
                    SoundManager.Instance.Play(Sounds.buttonClick);
                    SceneManager.LoadScene(LevelName);
                    break;

                case LevelStatus.Completed:
                    SoundManager.Instance.Play(Sounds.buttonClick);
                    SceneManager.LoadScene(LevelName);
                    break;
            }
        }
    }
}