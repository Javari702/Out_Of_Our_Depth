using UnityEngine;
using UnityEngine.UIElements;

public class PlayerDeath : MonoBehaviour
{
    Transform latestCheckpoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spikes.onDeath += ReturnToCheckpoint;
        GameManager.restartFromCheckpoint += ReturnToCheckpoint;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        Spikes.onDeath -= ReturnToCheckpoint;
        GameManager.restartFromCheckpoint -= ReturnToCheckpoint;
    }

    private void ReturnToCheckpoint()
    {
        transform.position = latestCheckpoint.position;
        Debug.Log("Returned to checkpoint");
    }

    public void UpdateLatestCheckpoint(Transform checkpoint)
    {
        latestCheckpoint = checkpoint;
        Debug.Log("Updated checkpoint");
    }
}
