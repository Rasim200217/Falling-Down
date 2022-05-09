using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ParticleSystem _death;
    public static GameManager Instance;

    [SerializeField] private Transform _playerTarget;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void RestartGame()
    {
        Invoke("RestarteAfterTime", 1f);
        StarText.Star = 0;
        Instantiate(_death, transform.position, Quaternion.identity);
    }
    
  

    void RestarteAfterTime()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
