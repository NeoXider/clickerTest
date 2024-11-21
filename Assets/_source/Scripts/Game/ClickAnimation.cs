using UnityEngine;
using UnityEngine.UI.Extensions;
using Zenject;

public class ClickAnimation : MonoBehaviour
{
    [SerializeField]
    private Transform _transformTextSpawn;

    [SerializeField]
    private Animator _animatorClick;

    [Inject]
    private TextClick _prefabTextClick;

    [Inject]
    private ClickerSettingsData _clickerSettingsData;

    [SerializeField] UIParticleSystem _uIParticleSystem;

    private int _clickTrigger = Animator.StringToHash("click");

    private void Awake() 
    {
        _prefabTextClick.SetAnimation(_clickerSettingsData.TextSpeed, _clickerSettingsData.TextTimeDestroy);
    }

    public void StartAnim(long click, bool passive = false)
    {
        Vector3 pos = passive ? _transformTextSpawn.position : Input.mousePosition;
        _uIParticleSystem.StartParticleEmission();
        CreateText(click, passive, pos);
        _animatorClick.SetTrigger(_clickTrigger);
    }

    private void CreateText(long click, bool passive, Vector3 pos)
    {

        TextClick textClick = Instantiate(_prefabTextClick, pos, Quaternion.identity, _transformTextSpawn);
        textClick.SetText(click);
    }
}
