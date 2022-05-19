using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public static int num;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {
            num = PlayerPrefs.GetInt("star");
            PlayerPrefs.SetInt("star", StarText.Star += 1);
            Destroy(gameObject);
        }
    }
}
