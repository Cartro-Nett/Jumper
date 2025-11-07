using UnityEngine;

public class MovePlayerAway : MonoBehaviour
{
    player_Movement player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            player.transform.position = new Vector3(-3.09f, 0.369f, -2.83f);
        }
    }
}
