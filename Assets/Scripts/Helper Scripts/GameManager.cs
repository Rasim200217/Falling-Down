using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject _death;
    public static GameManager Instance;

    public GameObject _playerTarget;

    public GameOver GameOver;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void RestartGame()
    {
        Instantiate(_death, _playerTarget.transform.position, Quaternion.identity);
        Invoke("RestarteAfterTime", 1f);
        _playerTarget.SetActive(false);
        GameOver.Setup(Star.num, Timer.TimeStart);
        Time.timeScale = 0f;
    }
    
  

    void RestarteAfterTime()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
