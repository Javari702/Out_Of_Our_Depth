using Unity.VisualScripting;
using UnityEngine;

public class teleport : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private GameObject locationOfTeleporter;

    [SerializeField] AudioClip teleportSFX;
    [SerializeField] float volumeOfClip;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        PlayerInteractController.onInteract += ActivateTeleport;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(locationOfTeleporter);
    }

    private void ActivateTeleport()
    {
        if (locationOfTeleporter != null)
        {
            transform.position = locationOfTeleporter.GetComponent<TeleporterSpotLogic>().getTeleportSpot().position;
            AudioManager.Instance?.playSFX(teleportSFX, 2f, 3f, volumeOfClip);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter Spot"))
        {
            locationOfTeleporter = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == locationOfTeleporter)
        {
            locationOfTeleporter = null;
        }
    }
}
