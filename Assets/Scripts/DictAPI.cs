using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class DictAPI
{
    public static string URL = "https://api.dictionaryapi.dev/api/v2/entries/en/";

    public static string RequestWordDefinition(string word)
    {
        string urlRequest = URL + word;
        UnityWebRequest webRequest = UnityWebRequest.Get(urlRequest);
        webRequest.SendWebRequest();
        while(!webRequest.isDone) {}
        if(webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error: " + webRequest.error);
            return null;
        }
        else
        {
            return webRequest.downloadHandler.text;
        }
    }
}
