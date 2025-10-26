using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerSidewaysMovement : MonoBehaviour
{
    public float speed;

    [SerializeField] int bubbleSpawnRate;
    [SerializeField] Animator playerAnimator;
    [SerializeField] VisualEffect movementParticles;
    [SerializeField] AudioClip movingNoise;
    [SerializeField] float timeBetweenMoveNoise;
    [SerializeField] float volumeofClip;

    private Rigidbody2D playerRigidbody;
    private SpriteRenderer playerSprite;
    private bool isMoving;
    private bool wasMoving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();

        if (isMoving && !wasMoving)
        {
            wasMoving = true;
            AudioManager.Instance?.playSFX(movingNoise, 0.8f, 1.2f, volumeofClip);
        }
        else if (!isMoving && wasMoving)
        {
            wasMoving = false;
        }
    }

    private void handleMovement()
    {
        float input = Input.GetAxis("Horizontal");
        float movingDirection = playerRigidbody.linearVelocityX = input * speed;

        if (movingDirection != 0)
        {
            isMoving = true;
            playerAnimator.SetBool("isRunning", true);
            movementParticles.SetInt("SpawnRate", bubbleSpawnRate);
        }
        else
        {
            isMoving = false;
            playerAnimator.SetBool("isRunning", false);
            movementParticles.SetInt("SpawnRate", 0);
        }


        if (input > 0)
        {
            playerSprite.flipX = false;
        }
        else if (input < 0)
        {
            playerSprite.flipX = true;
        }
    }

    // private IEnumerator playMoveNoise()
    // {
    //     while (true)
    //     {
    //         AudioManager.Instance?.playSFX(movingNoise, 0.8f, 1.2f);
    //         yield return new WaitForSeconds(timeBetweenMoveNoise);
    //     }
    // }
}
