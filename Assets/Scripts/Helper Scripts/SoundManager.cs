using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    [SerializeField] AudioSource _soundFx;

    [SerializeField] private AudioClip _landClip, _deathClip, _iceBreakClip, _gameOverClip;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
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
