using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
    public float timeBetweenChanges = 0.5f;
    public float fadeSpeed = 10f;
    public List<Sprite> imageList;
    private SpriteRenderer _spriteRenderer;
    private float _currentTime;
    private Timer _timer;
    private GameManager _gameManager;

    void Awake()
    {
        _timer = FindObjectOfType<Timer>();
        _gameManager = FindObjectOfType<GameManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
    }

    public IEnumerator SelectImage()
    {
        _currentTime = timeBetweenChanges;
        while (_currentTime > 0)
        {
            _spriteRenderer.sprite = imageList[UnityEngine.Random.Range(0, imageList.Count)];
            yield return new WaitForSeconds(timeBetweenChanges);
            _currentTime -= 0.01f;
            Debug.Log($"Current time : {_currentTime}");
        }
    }

    public IEnumerator Fade(float target, Action action = null)
    {
        Color col = _spriteRenderer.color;
        while (Mathf.Abs(col.a - target) > Mathf.Epsilon)
        {
            col.a = Mathf.MoveTowards(col.a, target, Time.deltaTime * fadeSpeed);
            _spriteRenderer.color = col;
            Debug.Log($"current alpha value : {col.a}");
            yield return null;
        }
        action?.Invoke();
    }
}
