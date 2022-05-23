using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSound : MonoBehaviour
{
    private static readonly string MusicPref = "MusicPref";
    
    private float _musicFloat;
    public AudioSource MusicAudio;

    private void Awake()
    {
        LevelSoundSettings();
    }

    private void LevelSoundSettings()
    {
        _musicFloat = PlayerPrefs.GetFloat(MusicPref);

        MusicAudio.volume = _musicFloat;
    }
}
