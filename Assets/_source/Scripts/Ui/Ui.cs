using System.Collections;
using UnityEngine;

public class Ui : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _pages;

    [SerializeField]
    private Animator _animatorChange;

    [SerializeField]
    private float _delayChangePage = 1;

    public int id;

    private int _changeTrigger = Animator.StringToHash("start");
    private bool _change;
    private WaitForSeconds _delay;

    private void Awake()
    {
        _delay = new WaitForSeconds(_delayChangePage);
    }

    public void SetPage(int id)
    {
        if (!_change && this.id != id)
        {
            this.id = id;
            StartCoroutine(SetPageCourotine(id));
        }
    }

    private IEnumerator SetPageCourotine(int id)
    {
        _change = true;

        _animatorChange.SetTrigger(_changeTrigger);

        yield return _delay;

        SetActivePage(id);

        _change = false;
    }

    public void SetActivePage(int id)
    {
        for (int i = 0; i < _pages.Length; i++)
        {
            _pages[i].SetActive(i == id);
        }
    }

    public float GetDelayChange()
    {
        return _delayChangePage;
    }
}
