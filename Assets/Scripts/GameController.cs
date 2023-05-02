using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] string guessWord;
    [SerializeField] Word[] words;
    private int currentWordIndex;

    private void Awake() 
    {
        if(words[0] != null)
        {
            currentWordIndex = 0;
        }
    }

    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // backspace/delete
            {
                words[currentWordIndex].DeleteLetter();
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                if(words[currentWordIndex].CheckWord()) // check if word is complete
                {
                    string completeWord = words[currentWordIndex].GetCompleteWord(); // get full word
                    string definition = DictAPI.RequestWordDefinition(completeWord); // request definition

                    if(definition != null)
                    {
                        Debug.Log(definition);
                        if(currentWordIndex < words.Length - 1)
                        {
                            currentWordIndex++;
                        }
                        else
                        {
                            Debug.Log("Game is over");
                        }
                    }
                    else
                    {
                        Debug.Log("No definition found");
                    }
                }
            }
            else
            {
                words[currentWordIndex].InputLetter(c.ToString());
            }
        }
    }


}
