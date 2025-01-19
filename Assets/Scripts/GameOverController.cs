using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    SoundManager soundManager;
    public Button RestartButton;

        private void Awake()
        {
          soundManager = SoundManager.Instance;
        }
    private void Start()
    {
        RestartButton.onClick.AddListener(ReloadLevel);
    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    private void ReloadLevel()
    {
        if (soundManager != null)
        {
            soundManager.PlayButtonClickAudio();
        }
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(CurrentScene.buildIndex);
    }


}
