using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        playButton.Select();
        playButton.onClick.AddListener(() => { Loader.Load(Loader.Scene.GameScene); });
        playButton.onClick.AddListener(() => { Application.Quit(); });

        Time.timeScale = 1;
    }
}
