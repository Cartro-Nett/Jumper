using UnityEngine;

public class TextureScroller : MonoBehaviour
{
    public Vector2 scrollSpeed = Vector2.zero;
    private Material mat;
    private Vector2 offset = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mat = GetComponent<Renderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        offset += scrollSpeed * Time.deltaTime;
        mat.mainTextureOffset = offset;
    }
}
