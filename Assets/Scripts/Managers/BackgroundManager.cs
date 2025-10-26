using UnityEngine;

//Adapted from https://youtu.be/AoRBZh6HvIk?si=JGrj3WQZczpKSc7e
public class BackgroundManager : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    public GameObject cam;
    public float parallaxEffect;
    private float distanceX;
    private float distanceY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        distanceX = cam.transform.position.x * parallaxEffect;
        distanceY = cam.transform.position.y * parallaxEffect;

        transform.position = new Vector3(startPosX + distanceX, startPosY + distanceY, transform.position.z);
    }
}