using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;
using System;

public class FactsItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _textId, _textFact;
    [SerializeField] private Image _imageLoad;
    public Button button;

    private void Awake()
    {
        _imageLoad.gameObject.SetActive(false);
        button.onClick.AddListener(LoadFactDetail);
    }

    public void LoadFactDetail()
    {
        StartRotationAnimation();
    }

    private void StartRotationAnimation()
    {
        _imageLoad.gameObject.SetActive(true);
        _imageLoad.transform.DORotate(new Vector3(0, 0, 360), 2f, RotateMode.FastBeyond360)
                  .SetEase(Ease.Linear)
                  .SetLoops(-1);
    }

    public void StopAllAnimations()
    {
        _imageLoad.transform.DOKill();
        _imageLoad.gameObject.SetActive(false);
    }

    internal void SetText(int id, string name)
    {
        _textId.text = (++id).ToString();
        _textFact.text = name;
    }
}
