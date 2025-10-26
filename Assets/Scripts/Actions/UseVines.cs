using UnityEngine;

public class UseVines : MonoBehaviour
{
    private bool inRange = false;
    // private MovingPlatform movingPlatform;

    // public delegate void ActivateVines();
    // public static ActivateVines onActivateVines;
    public SpriteRenderer outlineRenderer;
    public MovingPlatform movingPlatform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // movingPlatform = GetComponent<MovingPlatform>();
        PlayerInteractController.onInteract += ActivateVinesHelper;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActivateVinesHelper()
    {
        if (inRange)
        {
            movingPlatform.HoldPlatform();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            outlineRenderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            outlineRenderer.enabled = false;
        }
    }
}
