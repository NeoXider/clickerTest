using TMPro;
using UnityEngine;
using Zenject;
using UniRx;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [Inject] private Money _money;
    [Inject] private Energy _energy;
    [SerializeField] private TextMeshProUGUI[] _textMoneys;
    [SerializeField] private TextMeshProUGUI[] _textEnergys;
    [SerializeField] private TextMeshProUGUI _textWeather;
    [SerializeField] private Image _imageWeather;
    public PageFacts pageFacts;

    private CompositeDisposable _disposables = new CompositeDisposable();

    public void Awake()
    {
        _money.Value.Subscribe(value => { ChangeMoney(value); }).AddTo(_disposables);
        _energy.Value.Subscribe(value => { ChangeEnergy(value); }).AddTo(_disposables);
    }

    private void OnDestroy()
    {
        _disposables.Dispose();
    }

    public void ChangeMoney(long money)
    {
        foreach (var item in _textMoneys)
        {
            item.text = money.ToString();
        }
    }

    public void ChangeEnergy(int count)
    {
        foreach (var item in _textEnergys)
        {
            item.text = count.ToString();
        }
    }

    public void SetWeatherText(string text)
    {
        _textWeather.text = text;
    }

    public void SetWeatherIcon(Sprite ico)
    {
        _imageWeather.sprite = ico;
        //_imageWeather.SetNativeSize();
    }
}
