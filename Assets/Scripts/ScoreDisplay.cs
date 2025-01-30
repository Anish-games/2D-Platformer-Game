using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public static int ScoreValue;
    private TMP_Text Display;

    private void Awake()
    {
        ScoreValue = 0;
        Display = gameObject.GetComponent<TMP_Text>();
        if (Display == null)
        {
            Debug.LogError("TMP_Text component is not found on the GameObject. Make sure it is attached.");
        }
    }

    private void Update()
    {
        if (Display != null)
        {
            Display.text = "Score: " + ScoreValue;
        }
    }
}
