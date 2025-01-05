using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("hi this is player");
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision: "+ gameObject.name);
    }
}
