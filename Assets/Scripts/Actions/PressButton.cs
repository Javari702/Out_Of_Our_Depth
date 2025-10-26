using UnityEngine;
using UnityEngine.UI;

public class PressButton : MonoBehaviour
{
    public GameObject current;

    [SerializeField] Sprite buttonDown;

    private SpriteRenderer sprite;
    // public delegate void ActivateButton();
    // public static ActivateButton onButtonActivation;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sprite.sprite = buttonDown;
            // PlayerInteractController.onInteract?.Invoke();
            if (current != null)
            {
                current.GetComponent<CurrentLogic>().stopSound();
                Destroy(current);
            }
            
        }
    }
}
