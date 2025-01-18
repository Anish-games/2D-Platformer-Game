using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class LevelOverController : MonoBehaviour
{
    public int CurrentLevel;
    private void Awake()
    {
        Debug.Log("level over is activated");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
           
            int NextLevel = CurrentLevel + 1;
            Debug.Log("player finished the level.");
            //if (collision.gameObject.CompareTag("Player"))
            //{
            //    Debug.Log("player finished the level.");
            //}
            SceneManager.LoadScene(NextLevel);
        }
    }

    public void restartScene()
    {
        SceneManager.LoadScene(CurrentLevel);
    }
}
