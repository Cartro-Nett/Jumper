using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int health = 5;
    bool damagePause = false;
    bool invincible = false;
    [SerializeField] AudioSource audioSourceDamage;
    [SerializeField] AudioClip[] audioDamage;

    [SerializeField] GameManager gameManager;
    [SerializeField] HealthManager healthManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        healthManager = GameObject.FindWithTag("HealthManager").GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
       // Checks to see if player's death conditions.
        
        if (health <= 0 || transform.position.y < -7)
        {
            
            gameManager.gameOver();
            Destroy(gameObject);
            
        }
    }
    // The differnet ways the player could taken damage if the bools are false.
    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("DangerousGround") && damagePause == false && invincible == false)
        {
            audioSourceDamage.PlayOneShot(audioDamage[(int)Random.Range(0, audioDamage.Length)]);
            damagePause = true;
            Debug.Log(health);
            health--;
            healthManager.UpdateHealth();
            Invoke("damageBreak", 1f);
            
        }
        if (collision.CompareTag("Enemy") && damagePause == false && invincible == false)
        {
            audioSourceDamage.PlayOneShot(audioDamage[(int)Random.Range(0, audioDamage.Length)]);
            damagePause = true;
            Debug.Log(health);
            health--;
            healthManager.UpdateHealth();
            Invoke("damageBreak", 1f);
            
        }
        if (collision.CompareTag("Monster") && damagePause == false && invincible == false)
        {
            audioSourceDamage.PlayOneShot(audioDamage[(int)Random.Range(0, audioDamage.Length)]);
            damagePause = true;
            Debug.Log(health);
            health--;
            healthManager.UpdateHealth();
            Invoke("damageBreak", 1f);
           
        }
    }
    //Separated both the bools that stop damage to avoid any conflicts.
    void damageBreak()
    {
        damagePause = false;

    }
    public void invincibility()
    {
        invincible = true;
    }
}
