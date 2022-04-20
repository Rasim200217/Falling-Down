using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void RestartGame()
    {
        Invoke("RestarteAfterTime", 2f);
    }

    void RestarteAfterTime()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
