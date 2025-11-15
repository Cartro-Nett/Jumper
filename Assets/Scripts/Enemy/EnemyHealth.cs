using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHealth = 3;
    GameManager gameManager;
    [SerializeField] GameObject barriers;
    [SerializeField] GameObject breakableWall;
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
        if (CompareTag("KeyProtector") && enemyHealth < 10)
        {
            breakableWall.SetActive(true);
            transform.position = new Vector3(-20.79f, 14.61f, -18.36f);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (enemyHealth <= 0)
        {
            
            if(CompareTag("KeyProtector"))
            {
                barriers.SetActive(false);
                gameManager.addScore(200);
                Destroy(gameObject);
            }
            else
            {
                gameManager.addScore(20);
                Destroy(gameObject);
            }
            
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
