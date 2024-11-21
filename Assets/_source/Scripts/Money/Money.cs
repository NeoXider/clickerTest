using UniRx;
using UnityEngine;

public class Money : IMoney
{
    private IntReactiveProperty _value = new();

    public IntReactiveProperty Value => _value;

    public void Init()
    {
        Load();
        Value.Subscribe(x => { 
            Save(); 
            Debug.Log("Money value: " + Value);
            });

    }

    public void Add(int count)
    {
        if (count < 0)
            return;

        _value.Value += count;
    }

    public bool Spend(int count)
    {
        if (count < 0)
            return false;

        if (CanSpend(count))
        {
            _value.Value -= count;
            return true;
        }

        return false;
    }

    public void Set(int count = 0)
    {
        _value.Value = count;
    }

    private void Save()
    {
        string saveMoney = _value.ToString();

        PlayerPrefs.SetString(nameof(_value), saveMoney);
    }

    public bool CanSpend(int count)
    {
        return _value.Value >= count;
    }

    private void Load()
    {
        if (int.TryParse(PlayerPrefs.GetString(nameof(_value), "0"), out int money))
        {
            _value.Value = money;
        }
    }
}
