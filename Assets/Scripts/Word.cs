using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour
{
    [SerializeField] Letter[] letters;

    private int currentLetterIndex;

    private void Start() 
    {
        if(letters[0] != null)
        {
            currentLetterIndex = 0; 
        }
    }

    public void InputLetter(string input)
    {   
        letters[currentLetterIndex].InputLetter(input);
        if(currentLetterIndex < letters.Length - 1)
        {
            currentLetterIndex++;
        }
    }

    public void DeleteLetter()
    {
        if(letters[currentLetterIndex].GetLetter() != "")
        {
            letters[currentLetterIndex].Reset();
        }
        else if(currentLetterIndex > 0)
        {
            currentLetterIndex--;
            letters[currentLetterIndex].Reset();
        }
    }

    public bool CheckWord()
    {
        if(currentLetterIndex == letters.Length - 1 && letters[currentLetterIndex].GetLetter() != "")
        {   
            return true; 
        }
        else
        {
            return false;
        }
    }

    public string GetCompleteWord()
    {
        string word = "";
        foreach (Letter letter in letters)
        {
            word += letter.GetLetter();
        }
        return word;
    }


}
