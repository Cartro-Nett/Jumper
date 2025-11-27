using UnityEngine;

public class Mushrooms_bounce : MonoBehaviour
{
    player_Movement player;

    [SerializeField] float bouncePower = 25f;
    [SerializeField] AudioSource audioSourceBounce;
    [SerializeField] AudioClip[] audioBounce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                audioSourceBounce.PlayOneShot(audioBounce[(int)Random.Range(0, audioBounce.Length)]);
                Debug.Log(rb.linearVelocity);
                Vector3 newVelocity = rb.linearVelocity;
                newVelocity.y = bouncePower;
                rb.linearVelocity = newVelocity;
            }
            
        }
    }
    
}
