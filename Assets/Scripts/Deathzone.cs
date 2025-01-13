using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathzone : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("death zone is activated.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
   


