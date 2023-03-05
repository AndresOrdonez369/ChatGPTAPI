using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Text;
using System.IO;
public class ChatGPTForUnity : MonoBehaviour
{
   [SerializeField] private string APIKey;
   [TextArea(3, 10)] 
   [SerializeField] private string prompt;
   [TextArea(3, 10)] 
   [SerializeField] private string result;

   private readonly string chatGPTUrlAPI="https://api.openai.com/v1/completions";

   private readonly string scriptsFolder = "Assets/_Scripts";
   private readonly string directory = "ChatGPT";

   RequestBodyChatGPT requestBodyChatGPT;
   public void SendRequest()
   {
      result = string.Empty;
      requestBodyChatGPT = new requestBodyChatGPT();
      requestBodyChatGPT.model = "text-davinci-003";
      requestBodyChatGPT.prompt = prompt;
      requestBodyChatGPT.max_tokens = 2048;
      requestBodyChatGPT.temperature = 0;
   }

   private IEnumerator SendRequestAPI()
   {
      string jsonData = JsonUtility.ToJson(requestBodyChatGPT);
      byte[] rawData = Encoding.UTF8.GetBytes(jsonData);
      UnityWebRequest requestBodyChatGPT = new UnityWebRequest(chatGPTUrlAPI, "POST");
      requestChatGPT.uploadHandler = new UploadHandlerRaw(rawData);
      requestChatGPT.downloadhandler = new DownloadHandlerBuffer();
      //-H 'Content-Type: application/json' \
      //-H 'Authorization: Bearer YOUR_API_KEY' \
      requestChatGPT.SetRequestHeader("Content-Type","application/json");
      requestChatGPT.SetRequestHeader("Authorization","Bearer "+ APIKey);
      result = "Loading...";
      yield return requestChatGPT.SendWebRequest();
      if (requestChatGPT.result == UnityWebRequest.Result.Success)
      {
         
      }
   }
}

[Serializable]
public class RequestBodyChatGPT
{
   public string model;
   public string prompt;
   public int max_tokens;
   public int temperature;
   
}
