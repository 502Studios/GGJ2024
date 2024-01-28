using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
    public float timeBetweenChanges = 0.5f;
    public List<Sprite> imageList;
    private SpriteRenderer _spriteRenderer;
    private float _currentTime;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(SelectImage());
    }

    void Update()
    {
        
    }

    private IEnumerator SelectImage()
    {
        _currentTime = timeBetweenChanges;
        while (_currentTime > 0)
        {
            _spriteRenderer.sprite = imageList[Random.Range(0, imageList.Count)];
            yield return new WaitForSeconds(timeBetweenChanges);
            _currentTime -= 0.01f;
            Debug.Log($"Current time : {_currentTime}");
        }
    }
}
