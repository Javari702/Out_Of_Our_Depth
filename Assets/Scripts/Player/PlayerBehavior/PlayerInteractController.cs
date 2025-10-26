using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    public string interactButton;

    public delegate void OnInteract();
    public static OnInteract onInteract;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactButton)) onInteract?.Invoke();
    }
}
