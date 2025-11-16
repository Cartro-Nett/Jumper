using UnityEngine;

public class SuperPower : MonoBehaviour
{
    player_Movement player_M;
    Player_Health player_H;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_M = FindAnyObjectByType<player_Movement>();
        player_H = FindAnyObjectByType<Player_Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            player_M.jumpStr = 20;
            player_M.speed = 10;
            player_H.invincibility();
            gameObject.SetActive(false);
        }
    }
}
