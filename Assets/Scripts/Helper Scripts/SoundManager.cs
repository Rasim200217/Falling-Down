using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private Slider _volumeSlider = null;


    public static SoundManager Instance;

    [SerializeField] AudioSource _soundFx;

    [SerializeField] private AudioClip _landClip, _deathClip, _iceBreakClip, _gameOverClip;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        LoadValues();
    }

    public void SaveVolumeButton()
    {
        float volumeValue = _volumeSlider.value;
        PlayerPrefs.SetFloat("volumeValue", volumeValue);
        LoadValues();
        
        if(SceneManager.GetSceneByBuildIndex(0).isLoaded)
            Menu._menu.CancelOptions();
    }

    private void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("volumeValue");
        _volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }

    public void LandSound()
    {
        _soundFx.clip = _landClip;
        _soundFx.Play();
    }
    public void IceBreakSound()
    {
        _soundFx.clip = _iceBreakClip;
        _soundFx.Play();
    }
    public void DeathSound()
    {
        _soundFx.clip = _deathClip;
        _soundFx.Play();
    }
    public void GameOverSound()
    {
        _soundFx.clip = _gameOverClip;
        _soundFx.Play();
    }
    
}
