using UnityEngine;
using Zenject;

public class ClickerManager : MonoBehaviour
{
    [Inject] private ClickerSettingsData _clicerSettingsData;
    [Inject] private Money _money;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public int Click()
    {
        _money.Add(_clicerSettingsData.StartCountClick);

        return _clicerSettingsData.StartCountClick;
    }

    public void RestartGame()
    {
        _money.Set(0);
    }
}
