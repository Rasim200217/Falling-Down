using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public static int num = 0;
    public Text CountStarText;
    

    private void Awake()
    {
        num = PlayerPrefs.GetInt("starPoint", 0);
        CountStarText.text = num.ToString();

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Star"))
        {
            num++;
            CountStarText.text = num.ToString();
            PlayerPrefs.SetInt("starPoint", num);
            Destroy(collision.gameObject);
        }
    }
}
