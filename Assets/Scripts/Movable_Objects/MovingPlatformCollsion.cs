using UnityEngine;

public class MovingPlatformCollision : MonoBehaviour
{
    private Vector3 lastPosition;
    private Rigidbody playerRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // This will keep how far the platform has moved since last frame
        Vector3 move = transform.position - lastPosition;

        //The check to see if player is on the platform and
        //will move player in sync with the platform.
        if(playerRb != null)
        {
            playerRb.MovePosition(playerRb.position + move);
        }
        //To keep position of the platform up to date.
        lastPosition = transform.position;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRb = collision.gameObject.GetComponent<Rigidbody>();
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRb = null;
        }
    }
}
