using UnityEngine;
using UnityEngine.Audio;

public class EnemyAI : MonoBehaviour
{
    public float detectionRange = 8f;
    public float attackRange = 0.5f;
    public float chaseSpeed = 2f;
   

    private Transform player;
    
    [SerializeField] GameObject enemyProjectile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (gameObject.CompareTag("Enemy"))
        {
            InvokeRepeating("ThrowBall", 3f, 3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }
    void ChasePlayer()
    {
        if (player == null)
        {
            return;
        }
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < detectionRange && player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
            //FlipEnemy(player.position.x);
        }
        else
        {

        }



    }
    void FlipEnemy(float targetX)
    {
        if (targetX < transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, -1);
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("Player")) 
        {
            if (!CompareTag("Enemy"))
            {
               // MoveAfterAttack();  // I will need to work on this more for 3D games
            }

             
        }
    }
    public void MoveAfterAttack()
    {
        
        transform.Translate(-(player.position - transform.position).normalized * 3,Space.World);

    }

    public void ThrowBall()
    {
        if (player == null)  return;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);    

        

        if (distanceToPlayer <= detectionRange)
        {
            GameObject blueBall = Instantiate(enemyProjectile, transform.position, enemyProjectile.transform.rotation);

            Vector3 direction = (player.position - transform.position).normalized;

            Rigidbody rb = blueBall.GetComponent<Rigidbody>();
            rb.linearVelocity = direction * 8f;

            Destroy(blueBall, 3f);

        }


    }
}
