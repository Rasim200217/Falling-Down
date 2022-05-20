using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public static int num;
    public Text CountStarText;

    private void Start()
    {
        CountStarText.text = num.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Star"))
        {
            num = num++;
            CountStarText.text = num.ToString();
            Destroy(collision.gameObject);
            
            Debug.Log(num);
        }
    }
}
