using UnityEngine;

public class TeleporterSpotLogic : MonoBehaviour
{
    [SerializeField] Transform teleporterLocation;

    public Transform getTeleportSpot()
    {
        return teleporterLocation;
    }
}
