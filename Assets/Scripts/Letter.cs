using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    [SerializeField] TMP_Text letterText;
    [SerializeField] Image letterBackground;

    public void InputLetter(string input)
    {
        if(letterText.text == "")
        {
            letterText.text = input;
        }
    }

    public string GetLetter()
    {
        return letterText.text;
    }
    public void CorrectLetter()
    {
        letterBackground.color = Color.green;
    }

    public void SemiCorrectLetter()
    {
        letterBackground.color = Color.yellow;
    }

    public void WrongLetter()
    {
        letterBackground.color = Color.grey;
    }

    public void InvalidLetter()
    {
        letterBackground.color = Color.red;
    }

    public void Reset() 
    {
        letterBackground.color = Color.white;
        letterText.text = "";
    }
}
