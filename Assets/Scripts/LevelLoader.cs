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
        SceneManager.LoadScene(LevelName);
    }
}
