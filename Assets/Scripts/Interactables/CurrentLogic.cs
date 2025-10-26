using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CurrentLogic : MonoBehaviour
{
    [SerializeField] Vector2 force;
    [SerializeField] float power;
    [SerializeField] AudioClip currentNoise;
    [SerializeField] float volumeOfClip;

    void Start()
    {
        // PlayerInteractController.onInteract += deactivateCurrent;
        StartCoroutine(playSound());
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D player = collision.attachedRigidbody;

            if (player != null)
            {
                player.AddForce(force * power, ForceMode2D.Force);
            }
        }
    }

    public IEnumerator playSound()
    {
        while (true)
        {
            AudioManager.Instance?.playSFX(currentNoise, 0.8f, 1.2f, volumeOfClip, 3f);
            yield return null;   
        }
        
        
    }

    public void stopSound()
    {
        StopCoroutine(playSound());
    }

    // void deactivateCurrent()
    // {
    //     Destroy(gameObject);
    // }
}
