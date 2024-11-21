using UniRx;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class Energy : MonoBehaviour, IMoney
{
    [Inject] private ClickerSettingsData settingsData;
    private IntReactiveProperty _value = new();

    public IntReactiveProperty Value => _value;

    private void Awake()
    {
        _value.Value = PlayerPrefs.GetInt("Energy", settingsData.MaxEnergy);
        Value.Subscribe(value => { 
            PlayerPrefs.SetInt("Energy", value); 
            Debug.Log("Money value: " + Value);
            });

        InvokeRepeating(nameof(AddRepeating), settingsData.DelayAddEnergy, settingsData.DelayAddEnergy);
    }

    public void AddRepeating()
    {
        Add(settingsData.AddEnergy);
    }

    public void Add(int count)
    {
        Set(_value.Value + count);
    }

    public bool CanSpend(int count)
    {
        return _value.Value >= count;
    }

    public void Set(int count)
    {
        _value.Value = math.clamp((int)count, 0, settingsData.MaxEnergy);

    }

    public bool Spend(int count)
    {
        if( CanSpend(count))
        {
            Set(_value.Value - count);
            return true;
        }

        return false;
    }
}
