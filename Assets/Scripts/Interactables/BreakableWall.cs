using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public SpriteRenderer outlineRenderer;
    
    [SerializeField] AudioClip wallBreakNoise;
    [SerializeField] float volumeOfClip;

    private bool inRange = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerInteractController.onInteract += BreakWall;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BreakWall()
    {
        if (inRange)
        {
            AudioManager.Instance?.playSFX(wallBreakNoise, 2f, 3f, volumeOfClip);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            outlineRenderer.enabled = true;
        }
        // Debug.Log("trigger");
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
