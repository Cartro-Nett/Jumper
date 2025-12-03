using UnityEngine;

public class addToScore : MonoBehaviour
{
    public GameManager gameManager;
    bool oneKey =false;
    bool oneSuperPower = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    // Adds to the score all with different values, known by they tag name.
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("BronzeCoin"))
        {
            collision.enabled = false;
            gameManager.addScore(1);
            collision.gameObject.SetActive(false);
        }
        else if(collision.CompareTag("SilverCoin"))
        {
            collision.enabled = false;
            gameManager.addScore(5);
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("GoldCoin"))
        {
            collision.enabled = false;
            gameManager.addScore(20);
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Chest"))
        {
            collision.enabled = false;
            gameManager.addScore(75);
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Key") && oneKey == false)
        {
            gameManager.addScore(100);
            oneKey = true;
            Invoke("backToFalse", 3f);
        }
        else if (collision.CompareTag("SuperPowerUp") && oneSuperPower == false)
        {
            gameManager.addScore(2000);
            oneSuperPower = true;
            
        }

    }
    void backToFalse()
    {
        oneKey = false;
    }
}
