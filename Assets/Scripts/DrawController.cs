using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawController : MonoBehaviour
{
    public RenderTexture renderTexture;
    private Texture2D _texture2D;
    public RawImage _rawImage;
    private List<Vector2Int> _pointsInSpace;

    void Awake()
    {
        _rawImage = GetComponent<RawImage>();
        _texture2D = new Texture2D(renderTexture.width, renderTexture.height);
        _rawImage.material.mainTexture = _texture2D;

        _pointsInSpace = new List<Vector2Int>();
    }

    void LateUpdate()
    {
        RenderTexture.active = renderTexture;
        for (int x = 0; x < _pointsInSpace.Count; x++)
        {
            Vector2Int point = _pointsInSpace[x];
            _texture2D.SetPixel(point.x, point.y, Color.black);
        }
        _texture2D.Apply();
        RenderTexture.active = null;
    }

    public void AddPointToList(Vector2Int position)
    {
        _pointsInSpace.Add(position);
    }
}
