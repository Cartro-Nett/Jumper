using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceBackground;
    [SerializeField] AudioClip audioBackground;

    [SerializeField] float detectionRange = 100;
    private Transform player;

    GameManager gameManager;
    public bool isItPlaying = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
    }

    // Making it so if the player is in range it would start another audio
    // and stop the current one.
    void Update()
    {
       if (player == null)
       {
            return;
       }

       float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange && !audioSourceBackground.isPlaying)
        {
            Audio();
        }
        else if(distance > detectionRange && audioSourceBackground.isPlaying)
        {
            StopAudio();
        }
    }
    public void Audio()
    {
        Debug.Log("Its happening");
        audioSourceBackground.PlayOneShot(audioBackground);
        isItPlaying = true;
    }
        
    public void StopAudio()
    {
        Debug.Log("Anything");
        audioSourceBackground.Stop();
        isItPlaying = false;
    }
}
