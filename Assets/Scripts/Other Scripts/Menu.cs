using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameObject _panelOptions;
    
    private void Start()
    {
        _panelOptions = transform.GetChild(4).gameObject;
        _panelOptions.SetActive(false);
    }


    public void Play()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        _panelOptions.SetActive(true);
    }
    
    public void CancelOptions()
    {
        _panelOptions.SetActive(false);
    }
}
