using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

public class FactsRequest : MonoBehaviour
{
    [Inject]
    private Hud _hud;

    [Inject]
    private RequestQueueManager _requestQueueManager;

    [Inject] private ClickerSettingsData _clickerSettings;

    public void RequestFacts()
    {
        _requestQueueManager.CancelCurrentRequest();
        _requestQueueManager.EnqueueRequest(GetFacts());
    }

    private IEnumerator GetFacts()
    {
        UnityWebRequest request = UnityWebRequest.Get(_clickerSettings.WebFacts);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Facts request: " + request.downloadHandler.text);

            var jsonResponse = JsonUtility.FromJson<FactsResponse>(request.downloadHandler.text);

            _hud.pageFacts.DisplayFacts(jsonResponse.data);
        }
        else
        {
            Debug.LogError("Facts request failed: " + request.error);
        }
    }

    public void OnFactClicked(string factId)
    {
        _requestQueueManager.CancelCurrentRequest();
        _requestQueueManager.EnqueueRequest(GetFactDetails(factId));
    }

    private IEnumerator GetFactDetails(string factId)
    {
        string url = $"{_clickerSettings.WebFacts}/{factId}";
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {            
            var factDetail = JsonUtility.FromJson<FactDetailResponse>(request.downloadHandler.text);
            _hud.pageFacts.ShowFactDetailPopup(factDetail.data.attributes);
        }
        else
        {
            Debug.LogError("Fact detail request failed: " + request.error);
        }
    }
}

[System.Serializable]
public class FactsResponse
{
    public List<FactData> data;
}

[System.Serializable]
public class FactData
{
    public string id;
    public string type;
    public FactAttributes attributes;
}

[System.Serializable]
public class FactAttributes
{
    public string name;
    public int min_life;
    public int max_life;
    public string description;
    public bool hypoallergenic;
}

[System.Serializable]
public class FactDetailResponse
{
    public FactData data;
}