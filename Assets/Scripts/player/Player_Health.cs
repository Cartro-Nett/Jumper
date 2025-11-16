using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int health = 5;
    bool damagePause = false;
    bool invincible = false;
    [SerializeField] AudioSource audioSourceDamage;
    [SerializeField] AudioClip[] audioDamage;

    [SerializeField] GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if (health <= 0 || transform.position.y < -7)
        {
            
            gameManager.gameOver();
            Destroy(gameObject);
            
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("DangerousGround") && damagePause == false && invincible == false)
        {
            audioSourceDamage.PlayOneShot(audioDamage[0]);
            damagePause = true;
            Debug.Log(health);
            health--;
            Invoke("damageBreak", 1f);
            if (health < 2)
            {
                audioSourceDamage.PlayOneShot(audioDamage[1], 0.5f);
            }
        }
        if (collision.CompareTag("Enemy") && damagePause == false && invincible == false)
        {
            audioSourceDamage.PlayOneShot(audioDamage[0]);
            damagePause = true;
            Debug.Log(health);
            health--;
            Invoke("damageBreak", 1f);
            if (health < 2)
            {
                audioSourceDamage.PlayOneShot(audioDamage[1], 0.5f);
            }
        }
        if (collision.CompareTag("Monster") && damagePause == false && invincible == false)
        {
            audioSourceDamage.PlayOneShot(audioDamage[0]);
            damagePause = true;
            Debug.Log(health);
            health--;
            Invoke("damageBreak", 1f);
            if (health < 2)
            {
                audioSourceDamage.PlayOneShot(audioDamage[1], 0.5f);
            }
        }
    }
    void damageBreak()
    {
        damagePause = false;

    }
    public void invincibility()
    {
        invincible = true;
    }
}
