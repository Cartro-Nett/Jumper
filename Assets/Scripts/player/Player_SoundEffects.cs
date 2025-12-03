using UnityEngine;

public class Player_SoundEffects : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceEffects;
    [SerializeField] AudioClip[] audioEffects;
  
    // Keep all the pickup sounds on player, as the pickups disappear and wont be played.
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Heart"))
        {
            if (!audioSourceEffects.isPlaying)
            {
                audioSourceEffects.PlayOneShot(audioEffects[0]);
            }
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
