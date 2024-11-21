using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class TextClick : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup _canvasGroup;

    [SerializeField]
    private TextMeshProUGUI _text;
    private float _speed = 2f;
    private float _timeDestroy = 1.5f;
    private float _timer;
    private Vector3 _dir;

    void Start()
    {
        _dir = Vector3.up;
        _timer = _timeDestroy;
        Destroy(gameObject, _timeDestroy);
    }

    public void SetAnimation(float speed, float timeDestroy)
    {
        _speed = speed;
        _timeDestroy = timeDestroy;
    }

    private Vector2 GetRandomDir()
    {
        float angle = Random.Range(0f, 2f * Mathf.PI);
        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);
        return new Vector2(x, y);
    }

    void Update()
    {
        float deltaMove = _speed * Time.deltaTime;
        transform.localPosition += deltaMove * _dir;
        _timer -= Time.deltaTime;
        _canvasGroup.alpha = math.clamp(_timer / _timeDestroy, 0, 1);
    }

    internal void SetText(long click)
    {
        _text.text = "+" + NumberConverter.Convert(click);
    }

    private void OnValidate()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
}
