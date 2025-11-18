using UnityEngine;
using UnityEngine.EventSystems;

public class player_Movement : MonoBehaviour
{
    Rigidbody rb;
    public int speed = 5;
    public float jumpStr;
    public float defaultJumpStr;
    public float defaultSpeed;
    public bool onGround;

    public Transform cameraTransform;

    private AudioSource source;
    public AudioClip jumpSound;

    [SerializeField] GameManager gameManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultJumpStr = jumpStr;
        defaultSpeed = speed;
        source = GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        movement();
        jumping();
        pause();
    }
    void pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.pause();
        }
    }
    void movement()
    {

       
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Camera directions 
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        // This will flatten the movement
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        // Combines input and camera
        Vector3 moveDirection = camForward * moveVertical + camRight * moveHorizontal;

        // adds the velocity
        Vector3 velocity = moveDirection * speed;
        velocity.y = rb.linearVelocity.y;
        rb.linearVelocity = velocity;

        //Smooth rotation of the player
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
    void jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
           rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
           rb.AddForce(Vector3.up * jumpStr, ForceMode.Impulse);
           onGround = false;
           source.PlayOneShot(jumpSound, 0.2f);
        }
       
    }
}
