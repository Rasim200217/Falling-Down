using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text PointsText;
    

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        PointsText.text = score.ToString() + " STARS";
        Debug.Log(PointsText);
    }
}
