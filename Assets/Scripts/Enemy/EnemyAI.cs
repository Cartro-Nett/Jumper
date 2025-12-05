using UnityEngine;
using UnityEngine.Audio;

public class EnemyAI : MonoBehaviour
{
    public float detectionRange = 8f;
    public float attackRange = 0.5f;
    public float chaseSpeed = 2f;
    public float rotationSpeed = 4f;

    private Transform player;
    
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] AudioSource audioSourceShoot;
    [SerializeField] AudioClip[] audioShoot;
    [SerializeField] AudioSource audioSourceChase;
    [SerializeField] AudioClip audioChase;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Wanted to make it so its different times the method is being called and by different foes.
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (gameObject.CompareTag("Enemy"))
        {
            InvokeRepeating("ThrowBall", 2f, 2f);
        }
        if(gameObject.CompareTag("BossRightHand"))
        {
            InvokeRepeating("ThrowBall", 1.5f, 1.5f);
        }
        if(gameObject.CompareTag("BossUpperRightHand"))
        {
            InvokeRepeating("ThrowBall", 2.5f, 2.5f);
        }
        if(gameObject.CompareTag("BossUpperLeftHand"))
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
        // This was designed by a former colleague in collage to follow player. 
        if (player == null)
        {
            return;
        }
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < detectionRange && player != null)
        {
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, chaseSpeed * Time.deltaTime);


            Vector3 directionToPlayer = targetPosition - transform.position;
            
            // This will rotate the enemy to face the player.
            if (directionToPlayer.sqrMagnitude > 0.01f)
            {
                Quaternion look = Quaternion.LookRotation(directionToPlayer);
                transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * rotationSpeed);
                if(gameObject.CompareTag("Monster"))
                {
                    if(!audioSourceChase.isPlaying)
                    {
                        audioSourceChase.PlayOneShot(audioChase);
                    }
                    
                }
            }
            //transform.LookAt(player);
            //FlipEnemy(player.position.x);
            
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

    // The bullet all the enemies will fire.
    public void ThrowBall()
    {
        if (player == null)  return;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        

        if (distanceToPlayer <= detectionRange)
        {
            audioSourceShoot.PlayOneShot(audioShoot[(int)Random.Range(0, audioShoot.Length)]);
            GameObject blueBall = Instantiate(enemyProjectile, transform.position, enemyProjectile.transform.rotation);

            Vector3 direction = (player.position - transform.position).normalized;

            Rigidbody rb = blueBall.GetComponent<Rigidbody>();
            rb.linearVelocity = direction * 8f;
            
            Destroy(blueBall, 4f);

        }


    }
}
