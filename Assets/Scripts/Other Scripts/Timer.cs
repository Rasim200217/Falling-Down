using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float TimeStart = 0;

    public Text TimerText;
    public Text HighTimerText;

    public Font font;

    private int _timeHigh;
    void Start()
    {
        
        TimeStart = 0;
        TimerText.text = TimeStart.ToString();
        TimerText.font = font;
        HighTimerText.font = font;
    }

    // Update is called once per frame
    void Update()
    {
        _timeHigh = (int)TimeStart;
        TimeStart += Time.deltaTime;
        TimerText.text = "Время: " + Mathf.Round(TimeStart).ToString();

        if (PlayerPrefs.GetInt("time") <= _timeHigh)
            PlayerPrefs.SetInt("time", _timeHigh);

        HighTimerText.text = "Рекорд: " + PlayerPrefs.GetInt("time").ToString();
    }
}
