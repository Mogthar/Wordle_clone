using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class DictAPI
{
    public static string URL = "https://api.dictionaryapi.dev/api/v2/entries/en/";

    public static bool CheckWordExistence(string word)
    {
        string urlRequest = URL + word;
        UnityWebRequest webRequest = UnityWebRequest.Get(urlRequest);
        webRequest.SendWebRequest();
        while(!webRequest.isDone) {}
        if(webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            return false;
        }
        else
        {
            string jsonString = webRequest.downloadHandler.text;
            DictForm[] requestedForms = JsonHelper.FromJson<DictForm>(JsonHelper.fixJson(jsonString));
            Debug.Log(requestedForms[0].word);
            if(requestedForms[0].word != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
