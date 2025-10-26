using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//Adapted from https://youtu.be/GtX1p4cwYOc?si=1GFB4Krbm5gJ9cGs
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    public int startingPoint = 0;
    public Transform[] points;
    public bool flipSprite = false;
    public bool verticalMovement;

    private SpriteRenderer sprite;
    private int i;
    private bool vinesActive = false;
    private BoxCollider2D platformCollider;
    private Bounds platformBounds;
    private float platformLength;
    private float platformHeight;
    private float platformSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // transform.position = points[startingPoint].position;
        // UseVines.onActivateVines += HoldPlatform;
        sprite = GetComponent<SpriteRenderer>();
        platformCollider = GetComponent<BoxCollider2D>();
        platformBounds = platformCollider.bounds;
        platformLength = platformBounds.max.x - platformBounds.min.x;
        platformHeight = platformBounds.max.y - platformBounds.min.y;
        platformSize = platformLength;
        if (verticalMovement)
        {
            platformSize = platformHeight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < platformSize / 2)
        {
            if (flipSprite) sprite.flipX = true;
            i += 1;
            if (i == points.Length)
            {
                i = 0;
                sprite.flipX = false;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private IEnumerator StopPlatformMovement()
    {
        float oldSpeed = speed;
        speed = 0;
        yield return new WaitForSeconds(5);
        speed = oldSpeed;
        vinesActive = false;
    }

    public void HoldPlatform()
    {
        if (!vinesActive)
        {
            StartCoroutine(StopPlatformMovement());
            vinesActive = true;
            Debug.Log("activated vines");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

    private void OnDestroy()
    {
        // UseVines.onActivateVines -= HoldPlatform;
    }
}
