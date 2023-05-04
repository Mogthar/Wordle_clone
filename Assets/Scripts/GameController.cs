using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] string guessWord;
    [SerializeField] Word[] words;

    [SerializeField] float letterRevealDelay = 0.5f;
    [SerializeField] float wrongEntryDelay = 2.0f;
    private int currentWordIndex;

    [SerializeField] UnityEvent<int> onWordEntered = new UnityEvent<int>();

    private UIController uiController;

    private void Awake() 
    {
        if(words[0] != null)
        {
            currentWordIndex = 0;
        }
        uiController = FindObjectOfType<UIController>();
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
                    if(completeWord == guessWord)
                    {   
                        StartCoroutine(words[currentWordIndex].EvaluateWord(guessWord, letterRevealDelay));
                        StartCoroutine(WinGame());
                    }
                    else
                    {
                        bool isValidWord = DictAPI.CheckWordExistence(completeWord); // request definition

                        if(isValidWord)
                        {
                            StartCoroutine(words[currentWordIndex].EvaluateWord(guessWord, letterRevealDelay));
                            if(currentWordIndex < words.Length - 1)
                            {
                                onWordEntered.Invoke(currentWordIndex);
                                currentWordIndex++;
                            }
                            else
                            {
                                StartCoroutine(GameOver());
                            }
                        }
                        else
                        {
                            StartCoroutine(words[currentWordIndex].WrongEntry(wrongEntryDelay));
                        }
                    }
                }
            }
            else
            {
                words[currentWordIndex].InputLetter(c.ToString());
            }
        }
    }

    private IEnumerator WinGame()
    {
        yield return new WaitForSeconds(6 * letterRevealDelay);
        uiController.EnableWinWindow();
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(6 * letterRevealDelay);
        uiController.EnableRestartWindow();
    }
}
