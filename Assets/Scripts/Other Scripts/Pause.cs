using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private GameObject _panelPause;


    private void Start()
    {
        _panelPause = transform.GetChild(4).gameObject;
        _panelPause.SetActive(false);
    }

    public void PauseBtn()
    {
        Time.timeScale = 0;
        _panelPause.SetActive(true);
    }
    
    public void ContinueBtn()
    {
        Time.timeScale = 1;
        _panelPause.SetActive(false);
    }
}
