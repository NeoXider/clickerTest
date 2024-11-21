using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestQueueManager : MonoBehaviour
{
    private Queue<IEnumerator> _requestQueue = new Queue<IEnumerator>();
    private bool _isProcessing = false;
    private Coroutine _currentCoroutine;

    public void EnqueueRequest(IEnumerator request)
    {
        _requestQueue.Enqueue(request);
        if (!_isProcessing)
        {
            _currentCoroutine = StartCoroutine(ProcessQueue());
        }
    }

    public void CancelCurrentRequest()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
            _isProcessing = false;
        }
        _requestQueue.Clear();
    }

    private IEnumerator ProcessQueue()
    {
        _isProcessing = true;
        while (_requestQueue.Count > 0)
        {
            yield return StartCoroutine(_requestQueue.Dequeue());
        }
        _isProcessing = false;
    }
}