using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _panelOptions;
   [SerializeField] private GameObject _shopPlayerPanel;

   public static Menu _menu;
    
    private void Start()
    {
        _menu = this;
        
        _panelOptions.SetActive(false);
        _shopPlayerPanel.SetActive(false);
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
    public void ShopOpen()
    {
        _shopPlayerPanel.SetActive(true);
    }
    
    public void ShopExit()
    {
        _shopPlayerPanel.SetActive(false);
    }
}
