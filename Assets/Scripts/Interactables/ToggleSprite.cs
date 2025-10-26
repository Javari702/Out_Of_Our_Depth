using UnityEngine;

public class ToggleSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        AddEvents();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddEvents()
    {
        // BreakableWall.showOutline += showSprite;
        // BreakableWall.hideOutline += hideSprite;
    }

    private void OnDestroy()
    {
        // BreakableWall.showOutline -= showSprite;
        // BreakableWall.hideOutline -= hideSprite;
    }

    private void hideSprite()
    {
        spriteRenderer.enabled = false;
    }

    private void showSprite()
    {
        spriteRenderer.enabled = true;
    }
}
