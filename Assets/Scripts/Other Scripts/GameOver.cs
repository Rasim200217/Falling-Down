using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text PointsText;
    public Text TimeText;
    

    public void Setup(int score, float time)
    {
        gameObject.SetActive(true);
        PointsText.text = score.ToString() + "";
        TimeText.text = Mathf.Round(Timer.TimeStart).ToString() + " sec";
    }
}
