using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarText : MonoBehaviour
{
    public static int Star;
    private Text _countStarText;

    private void Start()
    {
        _countStarText = GetComponent<Text>();
    }
    private void Update()
    {
        _countStarText.text = Star.ToString();
    }
}
