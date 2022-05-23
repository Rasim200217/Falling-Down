using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
   private static readonly string FirstPlay = "FirstPlay";
   private static readonly string MusicPref = "MusicPref";

   private int _firstPlayInt;
   public Slider MusicSlider;
   private float _musicFloat;

   public AudioSource MusicAudio;


   private void Start()
   {
      _firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

      if (_firstPlayInt == 0)
      {
         _musicFloat = 0.25f;
         MusicSlider.value = _musicFloat;
         PlayerPrefs.SetFloat(MusicPref, _musicFloat);
         PlayerPrefs.SetInt(FirstPlay, -1);
      }
      else
      {
         _musicFloat = PlayerPrefs.GetFloat(MusicPref);
         MusicSlider.value = _musicFloat;
      }
   }

   public void SaveSoundSettings()
   {
      PlayerPrefs.SetFloat(MusicPref, MusicSlider.value);
   }

   private void OnApplicationFocus(bool hasFocus)
   {
      if(!hasFocus)
         SaveSoundSettings();
   }

   public void UpdateSound()
   {
      MusicAudio.volume = MusicSlider.value;
      
   }
}
