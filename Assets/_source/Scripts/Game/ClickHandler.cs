using UnityEngine;
using Zenject;

public class ClickHandler : MonoBehaviour
{
    [Inject]
    private AudioManager audioManager;

    [SerializeField]
    private ClickerManager _clickerManager;

    [SerializeField] ClickAnimation _clickAnimation;

    [Inject] private Energy _energy;

    public void OnClick(bool passive = false)
    {
        if (_energy.Spend(1))
        {
            int click = _clickerManager.Click();
            _clickAnimation.StartAnim(click, passive);
            audioManager.Play(1);
        }
    }
}
