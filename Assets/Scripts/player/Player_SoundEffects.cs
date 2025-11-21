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
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Heart"))
        {
            audioSourceEffects.PlayOneShot(audioEffects[0]);
        }
        if (collision.CompareTag("BronzeCoin"))
        {
            audioSourceEffects.PlayOneShot(audioEffects[1]);
        }
        if (collision.CompareTag("SilverCoin"))
        {
            audioSourceEffects.PlayOneShot(audioEffects[2]);
        }
        if (collision.CompareTag("GoldCoin"))
        {
            audioSourceEffects.PlayOneShot(audioEffects[3]);
        }
        if (collision.CompareTag("Chest"))
        {
            audioSourceEffects.PlayOneShot(audioEffects[4]);
        }
        if (collision.CompareTag("Key"))
        {
            audioSourceEffects.PlayOneShot(audioEffects[5]);
        }
        if (collision.CompareTag("SuperPowerUp"))
        {
            audioSourceEffects.PlayOneShot(audioEffects[6]);
        }

    }
}
