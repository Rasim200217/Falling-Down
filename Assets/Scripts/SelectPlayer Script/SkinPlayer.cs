using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinPlayer : MonoBehaviour
{
    public CharacterDatabase CharacterDatabase;
    
    public SpriteRenderer ArtworkSprite;
    
    private int _selectedOption = 0;


    private void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
            _selectedOption = 0;
        else
            Load();

        UpdateCharacter(_selectedOption);
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = CharacterDatabase.GetCharacter(selectedOption);
        ArtworkSprite.sprite = character.CharacterSprite;
    }

    private void Load()
    
    {
        _selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

}


