using UnityEngine;

// MADE BY CHATGPT

[RequireComponent(typeof(Renderer))]
public class UVScroller : MonoBehaviour
{
    public Vector2 tiling = new Vector2(2f, 1f);   // stretch horizontally
    public Vector2 speed  = new Vector2(0.02f, 0.01f);
    private Material mat;
    private Vector2 offset;

    void Awake()
    {
        mat = GetComponent<Renderer>().material;
        mat.mainTextureScale = tiling;
    }

    void Update()
    {
        offset += speed * Time.deltaTime;
        mat.mainTextureOffset = offset;
    }
}
