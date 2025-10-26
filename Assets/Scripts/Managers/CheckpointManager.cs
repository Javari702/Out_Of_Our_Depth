using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] PlayerDeath deathManager;
    [SerializeField] Sprite activatedSprite;
    [SerializeField] AudioClip checkpointNoise;
    [SerializeField] float volumeOfClip;

    private SpriteRenderer checkpointRenderer;
    private bool checkpointActivated;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkpointRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!checkpointActivated && collision.gameObject.CompareTag("Player"))
        {
            checkpointActivated = true;
            deathManager.UpdateLatestCheckpoint(transform);
            checkpointRenderer.sprite = activatedSprite;
            AudioManager.Instance?.playSFX(checkpointNoise, 0.8f, 1.2f, volumeOfClip);
        }
    }
}
