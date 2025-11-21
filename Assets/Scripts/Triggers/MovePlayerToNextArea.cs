using UnityEngine;

public class MovePlayerToNextArea : MonoBehaviour
{
    player_Movement player;
    [SerializeField] AudioSource audioTeleportEffects;
    [SerializeField] AudioClip audioTeleport;
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
        if (collision.CompareTag("Player"))
        {
            
            player.transform.position = new Vector3(18.9f, 0.369f, -29.83f);
            audioTeleportEffects.PlayOneShot(audioTeleport);
        }
    }
    
}
