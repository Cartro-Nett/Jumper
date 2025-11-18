using UnityEngine;

public class MoveToSecret : MonoBehaviour
{
    player_Movement player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<player_Movement>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {

            player.transform.position = new Vector3(-109.07f, 642.74f, 52.8f);

        }
    }

}
