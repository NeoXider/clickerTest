using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "Clicker/Skin", order = 32)]
public class SkinData : ScriptableObject
{
    [SerializeField]
    private Sprite _skin;

    [SerializeField]
    private int _count;

    [SerializeField]
    private int _startPrice;

    public int price;

    public Sprite skin => _skin;
    public int count => _count;

    public int SetStartPrtice()
    {
        price = _startPrice;
        return price;
    }
}
