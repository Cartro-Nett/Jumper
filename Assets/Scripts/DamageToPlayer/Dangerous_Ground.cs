using UnityEngine;

public class Dangerous_Ground : MonoBehaviour
{
    Player_Health player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player_Health>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    // Will keep hurting player, whilst the player is still in the area of Collison.
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.health--;
        }
    }
}
