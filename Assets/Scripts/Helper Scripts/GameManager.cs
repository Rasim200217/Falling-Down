using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void RestartGame()
    {
        Invoke("RestarteAfterTime", 0.5f);
    }
    
  

    void RestarteAfterTime()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
