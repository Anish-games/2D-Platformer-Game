using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button PlayButton;
    public Button QuitButton;
    public GameObject LevelSelector;
    SoundManager soundManager;

    private void Awake()
    {
        soundManager = SoundManager.Instance;
        PlayButton.onClick.AddListener(PlayGame);
        QuitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        if (soundManager != null)
        {
            soundManager.PlayButtonClickAudio();
        }
        Application.Quit();
    }

    private void PlayGame()
    {
        if (soundManager != null)
        {
            soundManager.PlayButtonClickAudio();
        }

        LevelSelector.SetActive(true);
    }
}
