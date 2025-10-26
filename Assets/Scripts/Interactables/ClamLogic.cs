using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ClamLogic : MonoBehaviour
{
    [SerializeField] Sprite closedClam;
    [SerializeField] Sprite openClam;
    [SerializeField] float closeTime;
    [SerializeField] float openTime;
    [SerializeField] AudioClip clamShutNoise;
    [SerializeField] AudioClip clamAboutToShutNoise;
    [SerializeField] float volumeOfClip;

    private SpriteRenderer clamSprite;
    private Spikes spikes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clamSprite = GetComponent<SpriteRenderer>();
        spikes = GetComponent<Spikes>();
        StartCoroutine(shutClam());
    }

    private IEnumerator shutClam()
    {
        while (true)
        {
            yield return new WaitForSeconds(openTime);
            AudioManager.Instance?.playSFX(clamShutNoise, 0.8f, 1.2f, volumeOfClip);
            clamSprite.sprite = closedClam;
            clamSprite.sortingLayerName = "Default";
            gameObject.GetComponent<Collider2D>().isTrigger = true;

            yield return new WaitForSeconds(closeTime);
            clamSprite.sprite = openClam;
            AudioManager.Instance?.playSFX(clamAboutToShutNoise, 0.8f, 1.2f, volumeOfClip, openTime);
            clamSprite.sortingLayerName = "Farground";
            gameObject.GetComponent<Collider2D>().isTrigger = false;
            
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            spikes.causeDeath();
        }
    }
}
