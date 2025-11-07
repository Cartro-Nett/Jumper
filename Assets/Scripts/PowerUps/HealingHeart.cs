using UnityEngine;

public class HealingHeart : MonoBehaviour
{
    [SerializeField] Player_Health player;
    private AudioSource Source;
    public AudioClip HealthSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<Player_Health>();
        Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Source.PlayOneShot(HealthSound);
            if (player.health < 5)
            {
                
                player.health++;
                Destroy(gameObject);
            }
            
        }
    }
}
