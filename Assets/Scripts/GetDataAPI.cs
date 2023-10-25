using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

public class GetDataAPI : MonoBehaviour
{
    public delegate void APICall(Wheeldata wd);
    public static event APICall obtainedWheelData;

    [Header ("API calls")]
    public string Get_URL;
    public string Post_URL;
    public string api_key;

    public Wheeldata wheelInfo;
    public WheelReward reward;

    private void Awake()
    {
        GetData();
    }

    private void OnEnable()
    {
        WheelSpin.SpinOver += ReturnReward;
    }

    private void OnDisable()
    {
        WheelSpin.SpinOver -= ReturnReward;
    }


    public void GetData()
    {
        StartCoroutine(FetchData());
    }


    IEnumerator FetchData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(Get_URL))
        {
            webRequest.SetRequestHeader("Authorization", api_key);

            yield return webRequest.SendWebRequest();


            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                wheelInfo = JsonUtility.FromJson<Wheeldata>(webRequest.downloadHandler.text);
                //Debug.LogError(webRequest.downloadHandler.text);
            }
        }
        obtainedWheelData?.Invoke(wheelInfo);
    }

    private void ReturnReward(int rewardIndex)
    {
        StartCoroutine(PostData(rewardIndex));
    }


    IEnumerator PostData(int rewardIndex)
    {
        reward.selected_id = rewardIndex;
        string jsonRaw = JsonUtility.ToJson(reward);
        Debug.LogError(jsonRaw);
        byte[] Body = Encoding.UTF8.GetBytes(jsonRaw);

        var webRequest = new UnityWebRequest(Post_URL, "POST");

        webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(Body);
        webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");
        webRequest.SetRequestHeader("Authorization", api_key);

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            Debug.LogError(webRequest.downloadHandler.text);
        }

    }


    /////////////////////////////////------------------- Generic Type ------------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    public void GetAPIINFO<T>(T funcff)
    {
        StartCoroutine(GetAPI_Universal(funcff, Get_URL));
    }

    IEnumerator GetAPI_Universal<T>(T dataContainer, string getURL)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(getURL))
        {
            webRequest.SetRequestHeader("Authorization", api_key);

            yield return webRequest.SendWebRequest();


            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                dataContainer = JsonUtility.FromJson<T>(webRequest.downloadHandler.text);

            }
        }
    }

    IEnumerator PostData_Universal<T>(T data, string postURL)
    {
        //data.selected_id = rewardIndex;
        string jsonRaw = JsonUtility.ToJson(data);
        Debug.LogError(jsonRaw);
        byte[] Body = Encoding.UTF8.GetBytes(jsonRaw);

        var webRequest = new UnityWebRequest(postURL, "POST");

        webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(Body);
        webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");
        webRequest.SetRequestHeader("Authorization", api_key);

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            Debug.LogError(webRequest.downloadHandler.text);
        }

    }

}


[System.Serializable]
public class WheelInfo
{
    public int id;
    public string offer;
    public string color;
}

[System.Serializable]
public class Wheeldata
{
    public WheelInfo[] data;
}

[System.Serializable]
public class WheelReward
{
    public int selected_id;
}