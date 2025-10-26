using UnityEngine;

public class Collectable : MonoBehaviour
{
    //[SerializeField] AudioClip winNoise;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            //AudioManager.Instance?.playSFX(winNoise, 0.8f, 1.5f);
        }
    }
}
