using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    public delegate void OnDeath();
    public static OnDeath onDeath;

    [SerializeField] AudioClip spikeNoise;
    [SerializeField] float volumeOfClip;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance?.playSFX(spikeNoise, 0.75f, 1.5f, volumeOfClip);
            onDeath?.Invoke();
        }
    }

    // public void RestartScene()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //     PlayerDeath.onDeath -= RestartScene;
    // }

    public void causeDeath()
    {
        onDeath?.Invoke();
    }
}
