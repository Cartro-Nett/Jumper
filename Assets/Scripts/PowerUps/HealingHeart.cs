using UnityEngine;

public class HealingHeart : MonoBehaviour
{
    [SerializeField] Player_Health player;
    [SerializeField] HealthManager healthManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<Player_Health>();
        healthManager = GameObject.FindWithTag("HealthManager").GetComponent<HealthManager>();

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            if (player.health < 5)
            {
                
                player.health++;
                healthManager.UpdateHealth();
                Destroy(gameObject);
            }
            
        }
    }
}
