using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWindow : MonoBehaviour
{
    private void Awake() 
    {
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
