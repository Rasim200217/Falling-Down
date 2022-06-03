using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase CharacterDatabase;

    public Text NameText;
    public SpriteRenderer ArtworkSprite;
    public Image AtworkImage;
    
    private int _selectedOption = 0;


    private void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
            _selectedOption = 0;
        else
          Load();

        UpdateCharacter(_selectedOption);
    }

    public void NextOption()
    {
        _selectedOption++;

        if (_selectedOption >= CharacterDatabase.CharacterCount)
            _selectedOption = 0;
        
        UpdateCharacter(_selectedOption);
        Save();
        
    }

    public void BackOption()
    {
        _selectedOption--;

        if (_selectedOption < 0)
            _selectedOption = CharacterDatabase.CharacterCount - 1;
        
        UpdateCharacter(_selectedOption);
        Save();

    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = CharacterDatabase.GetCharacter(selectedOption);
        ArtworkSprite.sprite = character.CharacterSprite;
        AtworkImage.sprite = character.CharacterSprite;
        NameText.text = character.CharacterName;
    }

    private void Load()
    {
        _selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    
    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", _selectedOption);
    }

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
