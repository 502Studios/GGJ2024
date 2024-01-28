using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
    public float timeBetweenChanges = 0.5f;
    public float fadeSpeed = 10f;
    public List<ImageItem> imageList;
    private SpriteRenderer _spriteRenderer;
    private float _currentTime;
    private int _selectedIndex;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator SelectImage()
    {
        _currentTime = timeBetweenChanges;
        while (_currentTime > 0)
        {
            _selectedIndex = UnityEngine.Random.Range(0, imageList.Count);
            _spriteRenderer.sprite = imageList[_selectedIndex].sprite;
            yield return new WaitForSeconds(timeBetweenChanges);
            _currentTime -= 0.01f;
            Debug.Log($"Current time : {_currentTime}");
        }
    }

    public int GetImageTime()
    {
        return imageList[_selectedIndex].time;
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

    public IEnumerator FadeLerp()
    {
        Color col = _spriteRenderer.color;
        while (true)
        {
            col = new Color(1f, 1f, 1f, Mathf.Cos(Time.time));
            _spriteRenderer.color = col;
            yield return null;
        }
    }

    [Serializable]
    public class ImageItem
    {
        public Sprite sprite;
        public int time;
    }
}
