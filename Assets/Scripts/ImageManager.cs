using System.Collections.Generic;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
    public List<Sprite> imageList;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _spriteRenderer.sprite = imageList[Random.Range(0, imageList.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
