using UnityEngine;
using UnityEngine.UI;

public class DrawController : MonoBehaviour
{
    public RenderTexture renderTexture;
    private Texture2D _texture2D;
    public RawImage _rawImage;

    void Awake()
    {
        _rawImage = GetComponent<RawImage>();
        _texture2D = new Texture2D(renderTexture.width, renderTexture.height);
        _rawImage.material.mainTexture = _texture2D;
    }

    void Update()
    {
        RenderTexture.active = renderTexture;

        _texture2D.Apply();
        RenderTexture.active = null;
    }
}
