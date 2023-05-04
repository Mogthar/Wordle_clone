using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text hintText;
    [SerializeField] WinWindow winWindow;

    [SerializeField] RestartWindow restartWindow;

    [SerializeField] string[] hints;

    [SerializeField] float hintDelay = 3f;

    public void EnableWinWindow()
    {
        winWindow.gameObject.SetActive(true);
    }

    public void EnableRestartWindow()
    {
        restartWindow.gameObject.SetActive(true);
    }

    private void Start()
    {
        hintText.text = hints[0];
        TouchScreenKeyboard keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    public void ShowHintOnWordEnter(int wordIndex)
    {   
        if(wordIndex < hints.Length - 1)
        {
            StartCoroutine(ShowHint(wordIndex + 1));
        }
    }

    private IEnumerator ShowHint(int hintIndex)
    {
        yield return new WaitForSeconds(hintDelay);
        hintText.text = hints[hintIndex];
    }

}
