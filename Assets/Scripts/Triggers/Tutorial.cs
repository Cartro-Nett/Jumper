using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject objects;
    player_Movement player;
    [SerializeField] AudioSource audioSourceSpawnerEffects;
    [SerializeField] AudioClip audioSpawnerEffects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<player_Movement>();
    }
    //Will let the player see the message as long as their are in the collider area.
    private void OnTriggerStay(Collider collision)
    {

        if (collision.CompareTag("Player"))
        {
           objects.SetActive(true);
        }
    }
    //To deactivate the message to player
    private void OnTriggerExit(Collider Collision)
    {
        objects.SetActive(false);
        if (audioSpawnerEffects != null && !audioSourceSpawnerEffects.isPlaying)
        {
            audioSourceSpawnerEffects.PlayOneShot(audioSpawnerEffects);
            Debug.Log("Audio Played");
        }
    }

}
