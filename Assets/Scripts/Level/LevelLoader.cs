using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;

    public string LevelName;
    private  SoundManager soundManager;

    private void Awake()
    {
        soundManager = SoundManager.Instance;
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        if (soundManager != null)
        {
            soundManager.PlayButtonClickAudio();
        }
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch (levelStatus)
        { 
            case LevelStatus.Locked:
                Debug.Log("Level Locked , Can't play.");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelName);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(LevelName);
                Debug.Log("Level Complete.");
                break;
        }
        SceneManager.LoadScene(LevelName);
    }
}
