using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private GameObject _panelPause;

    private GameObject _panelDead;


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

    public void RestartBtn()
    {
        Time.timeScale = 1;
        GameManager.Instance.RestartGame();
        SoundManager.Instance.GameOverSound();
        _panelPause.SetActive(false);
    }

    public void ExitMenuBtn()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
        Time.timeScale = 1;
    }

}
