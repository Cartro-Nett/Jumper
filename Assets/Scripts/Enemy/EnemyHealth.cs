using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHealth = 3;
    GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        death();
    }
    void death()
    {
        if (enemyHealth <= 0)
        {
            gameManager.addScore(20);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            gameManager.addScore(5);
            enemyHealth--;
        }
        if(collision.CompareTag("BigBullet"))
        {
            gameManager.addScore(10);
            enemyHealth = enemyHealth - 3;
        }
    }

}
