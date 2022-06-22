using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase CharacterDatabase;
    

    public Text NameText;
    public Text PriceText;
    public SpriteRenderer ArtworkSprite;
    public Image AtworkImage;
    
    private int _selectedOption = 0;

    public Button UnlockButton;
    public TextMeshProUGUI starCoinText;


    private void Awake()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
            _selectedOption = 0;
        else
            Load();

        UpdateCharacter(_selectedOption);
        
        foreach (Character c in CharacterDatabase.Characters)
        {
            if (c.CharacterPrice == 0)
                c.IsUnlocked = true;
            else
            {
                c.IsUnlocked = PlayerPrefs.GetInt(c.CharacterName, 0) == 0 ? false : true;
            }
        }
        
        UpdateUI();
        
    }

    private void Start()
    {
      
        
        
    }
    
    public void NextOption()
    {
        _selectedOption++;

        if (_selectedOption >= CharacterDatabase.CharacterCount)
            _selectedOption = 0;
        
       
        UpdateCharacter(_selectedOption);
        Save();
        
        UpdateUI();
    }

    public void BackOption()
    {
        _selectedOption--;

        if (_selectedOption < 0)
            _selectedOption = CharacterDatabase.CharacterCount - 1;
        
        UpdateCharacter(_selectedOption);
        Save();
        
        UpdateUI();
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = CharacterDatabase.GetCharacter(selectedOption);
        ArtworkSprite.sprite = character.CharacterSprite;
        AtworkImage.sprite = character.CharacterSprite;
        NameText.text = character.CharacterName;
        PriceText.text = character.CharacterPrice.ToString();
        
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

    public void UpdateUI()
    {
        starCoinText.text = "" + PlayerPrefs.GetInt("starPoint", 0);
        if(CharacterDatabase.Characters[_selectedOption].IsUnlocked == true)
            UnlockButton.gameObject.SetActive(false);
        else
        {
            UnlockButton.GetComponentInChildren<TextMeshProUGUI>().text =
                "Price: " + CharacterDatabase.Characters[_selectedOption].CharacterPrice;
            if (PlayerPrefs.GetInt("starPoint", 0) < CharacterDatabase.Characters[_selectedOption].CharacterPrice)
            {
                UnlockButton.gameObject.SetActive(true);
                UnlockButton.interactable = false;
            }
            else
            {
                UnlockButton.gameObject.SetActive(true);
                UnlockButton.interactable = true;
            }
        }
    }

    public void Unlock()
    {
        int stars = PlayerPrefs.GetInt("starPoint", 0);
        int price = CharacterDatabase.Characters[_selectedOption].CharacterPrice;
        PlayerPrefs.SetInt("starPoint", stars - price);
        PlayerPrefs.SetInt(CharacterDatabase.Characters[_selectedOption].CharacterName, 1);
        PlayerPrefs.SetInt("selectedOption", _selectedOption);
        CharacterDatabase.Characters[_selectedOption].IsUnlocked = true;
        UpdateUI();
    }
}
