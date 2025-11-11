using UnityEngine;

public class addToScore : MonoBehaviour
{
    public GameManager gameManager;
    bool oneKey =false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("BronzeCoin"))
        {
            gameManager.addScore(1);
            collision.gameObject.SetActive(false);
        }
        else if(collision.CompareTag("SilverCoin"))
        {
            gameManager.addScore(5);
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("GoldCoin"))
        {
            gameManager.addScore(20);
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Chest"))
        {
            gameManager.addScore(75);
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Key") && oneKey == false)
        {
            gameManager.addScore(100);
            oneKey = true;
            Invoke("backToFalse", 3f);
        }
        else if (collision.CompareTag("SuperPowerUp"))
        {
            gameManager.addScore(2000);
            
        }

    }
    void backToFalse()
    {
        oneKey = false;
    }
}
