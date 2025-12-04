using UnityEngine;

public class Spawn_Objects : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    player_Movement player;
    [SerializeField] AudioSource audioSourceSpawnerEffects;
    [SerializeField] AudioClip audioSpawnerEffects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<player_Movement>();
    }
    //Will go for all in the array of objects and make them all active to be seen by player.
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger!");
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(true);
                if(audioSpawnerEffects != null && !audioSourceSpawnerEffects.isPlaying)
                {
                    audioSourceSpawnerEffects.PlayOneShot(audioSpawnerEffects);
                    Debug.Log("Audio Played");
                }
                
            }
            
                Invoke("getRid", 3f);
            
            
            
        }
    }
    //To get rid of the the spawner object so the player cant re-enter and create an error.
    void getRid()
    {
        gameObject.SetActive(false);
    }
    
}
