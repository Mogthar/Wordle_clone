using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    public IEnumerator EvaluateWord(string guessWord, float delay)
    {
        yield return new WaitForSeconds(delay);
        for(int i = 0; i < letters.Length; i++)
        {
            if(letters[i].GetLetter() == guessWord[i].ToString())
            {
                letters[i].CorrectLetter();
            }
            else if(guessWord.Any(character => character == letters[i].GetLetter().ToCharArray()[0]))
            {
                int counter = 0;
                for(int j = 0; j < guessWord.Length; j++)
                {
                    if(guessWord[j] == letters[i].GetLetter().ToCharArray()[0] && guessWord[j] != letters[j].GetLetter().ToCharArray()[0])
                    {
                        counter++;
                    }
                }
                if(counter > 0)
                {
                    letters[i].SemiCorrectLetter();
                }
                else
                {
                    letters[i].WrongLetter();
                }
            }
            else
            {
                letters[i].WrongLetter();
            }
            yield return new WaitForSeconds(delay);
        }
    }

    public IEnumerator WrongEntry(float delay)
    {
        foreach (Letter letter in letters)
        {
            letter.InvalidLetter();
        }
        yield return new WaitForSeconds(delay);
        ResetWord();
    }

    private void ResetWord()
    {
        foreach (Letter letter in letters)
        {
            letter.Reset();
        }
        currentLetterIndex = 0;
    }
}
