using UnityEngine;

public class Player_SoundEffects : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceEffects;
    [SerializeField] AudioClip[] audioEffects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider Collison)
    {
        if (Collison.CompareTag("Heart"))
        {
            audioSourceEffects.PlayOneShot(audioEffects[0]);
        }
        
    }
}
