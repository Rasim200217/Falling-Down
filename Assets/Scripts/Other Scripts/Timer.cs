using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float TimeStart = 0;
    public Text TimerText;
    void Start()
    {
        TimerText.text = TimeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        TimeStart += Time.deltaTime;
        TimerText.text = "Time: " + Mathf.Round(TimeStart).ToString();
    }
}
