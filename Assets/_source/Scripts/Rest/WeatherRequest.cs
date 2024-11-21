using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

public class WeatherRequest : MonoBehaviour
{
    [Inject]
    private Ui _ui;

    [Inject]
    private Hud _hud;

    [Inject]
    private RequestQueueManager _requestQueueManager;

    [Inject] private ClickerSettingsData _clickerSettings;

    private void Start()
    {
        StartCoroutine(WeatherRequestRoutine());
    }

    private IEnumerator WeatherRequestRoutine()
    {
        while (true)
        {
            if (UserIsOnClickerScreen())
            {
                _requestQueueManager.CancelCurrentRequest();
                _requestQueueManager.EnqueueRequest(GetWeather());
            }

            yield return new WaitForSeconds(5f);
        }
    }

    private IEnumerator GetWeather()
    {
        UnityWebRequest request = UnityWebRequest.Get(_clickerSettings.WebWeather);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Weather request: " + request.downloadHandler.text);

            var jsonResponse = JsonUtility.FromJson<WeatherResponse>(request.downloadHandler.text);

            var todayWeather = jsonResponse.properties.periods[0];

            string weatherText = $"Today - {todayWeather.temperature}{todayWeather.temperatureUnit}";

            _hud.SetWeatherText(weatherText);

            yield return LoadWeatherIcon(todayWeather.icon);
        }
        else
        {
            Debug.LogError("Weather request failed: " + request.error);
        }
    }

    private IEnumerator LoadWeatherIcon(string iconUrl)
    {
        UnityWebRequest iconRequest = UnityWebRequestTexture.GetTexture(iconUrl);
        yield return iconRequest.SendWebRequest();

        if (iconRequest.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(iconRequest);
            Sprite weatherIcon = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            _hud.SetWeatherIcon(weatherIcon);
        }
        else
        {
            Debug.LogError("Icon request failed: " + iconRequest.error);
        }
    }

    private bool UserIsOnClickerScreen()
    {
        return _ui.id == 0;
    }
}

[System.Serializable]
public class WeatherResponse
{
    public WeatherProperties properties;
}

[System.Serializable]
public class WeatherProperties
{
    public WeatherPeriod[] periods;
}

[System.Serializable]
public class WeatherPeriod
{
    public string name;
    public int temperature;
    public string temperatureUnit;
    public string icon;
}