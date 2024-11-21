using UnityEngine;

[CreateAssetMenu(fileName = "ClickerSettings", menuName = "Clicker/Settings", order = 32)]
public class ClickerSettingsData : ScriptableObject
{
    [Header("Main")]
    [Header("Click")]
    [SerializeField] private int _startCountClick = 1;
    [SerializeField] private float _delayClickPassive = 3;

    [Space]
    [Header("Echonomy")]
    [SerializeField] private int _maxEnergy = 1000;
    [SerializeField] private int _addEnergy = 10;
    [SerializeField] private float _delayAddEnergy = 10;

    [Space]
    [Header("Rest")]
    [SerializeField]
    private string _webWeather = "https://api.weather.gov/gridpoints/TOP/32,81/forecast";
    [SerializeField]
    private string _webFacts = "https://dogapi.dog/docs/api-v2";

    [Space]
    [Header("Animation")]
    [SerializeField] private float _textSpeed = 2;
    [SerializeField] private float _textTimeDestroy = 1f;

    public int StartCountClick => _startCountClick;
    public float DelayClickPassive => _delayClickPassive;
    public float TextSpeed => _textSpeed;
    public float TextTimeDestroy => _textTimeDestroy;
    public int MaxEnergy => _maxEnergy;
    public int AddEnergy => _addEnergy;
    public float DelayAddEnergy => _delayAddEnergy;
    public string WebWeather => _webWeather;
    public string WebFacts => _webFacts;


}
