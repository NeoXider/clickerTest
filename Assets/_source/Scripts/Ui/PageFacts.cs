using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

public class PageFacts : MonoBehaviour
{
    [SerializeField] private Transform _transformFactsContainer;
    [SerializeField] private GameObject _loadFacts;
    [SerializeField] private GameObject _factPopUp;

    [SerializeField] private TMP_Text _textTitle, _textDescription;

    [Inject] private FactsItem _factsItemPrefab;
    [Inject] private FactsRequest _factsRequest;
    private List<FactsItem> _factsItems = new();

    private void OnEnable()
    {
        _loadFacts.SetActive(true);
        _factPopUp.SetActive(false);
        _factsRequest.RequestFacts();
    }

    public void DisplayFacts(List<FactData> facts)
    {
        foreach (Transform child in _transformFactsContainer)
        {
            Destroy(child.gameObject);
        }

        _factsItems.Clear();

        for (int i = 0; i < facts.Count; i++)
        {
            FactData fact = facts[i];
            FactsItem factItem = Instantiate(_factsItemPrefab, _transformFactsContainer);
            factItem.SetText(i, fact.attributes.name);
            factItem.button.onClick.AddListener(() => { _factsRequest.OnFactClicked(fact.id); });
            _factsItems.Add(factItem);
        }

        _loadFacts.SetActive(false);
    }

    public void ShowFactDetailPopup(FactAttributes attributes)
    {
        Debug.Log($"Fact: {attributes.name}\nDescription: {attributes.description}");
        _textTitle.text = attributes.name;
        _textDescription.text =attributes.description;

        StopAllAnimation();
        ShowPopup();
    }

    private void ShowPopup()
    {
        _factPopUp.SetActive(true);

        _factPopUp.transform.localScale = Vector3.zero;
        _factPopUp.transform.DOScale(1f, 0.8f).SetEase(Ease.OutBack);
    }

    private void StopAllAnimation()
    {
        foreach (var fact in _factsItems)
        {
            fact.StopAllAnimations();
        }
    }
}
