using UnityEngine;

public class HealingHeart : MonoBehaviour
{
    [SerializeField] Player_Health player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<Player_Health>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            if (player.health < 5)
            {
                
                player.health++;
                Destroy(gameObject);
            }
            
        }
    }
}
