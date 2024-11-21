using UnityEngine;
using Zenject;

public class PassiveClick : MonoBehaviour
{
    [Inject] private ClickerSettingsData _clickerSettingsData;

    [Inject, SerializeField] private ClickHandler _clickHandler;

    void Start()
    {
        InvokeRepeating(nameof(OnClick), _clickerSettingsData.DelayClickPassive, _clickerSettingsData.DelayClickPassive);
    }
    
    private void OnClick()
    {
        _clickHandler.OnClick(true);
    }
}
