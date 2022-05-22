using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float TimeStart = 0;

    public Text TimerText;
    public Text HighTimerText;

    private int _timeHigh;
    void Start()
    {
        TimeStart = 0;
        TimerText.text = TimeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        _timeHigh = (int)TimeStart;
        TimeStart += Time.deltaTime;
        TimerText.text = "Time: " + Mathf.Round(TimeStart).ToString();

        if (PlayerPrefs.GetInt("time") <= _timeHigh)
            PlayerPrefs.SetInt("time", _timeHigh);

        HighTimerText.text = "HighTime " + PlayerPrefs.GetInt("time").ToString();
    }
}
