using UnityEngine;

public class MoveToTop : MonoBehaviour
{
    player_Movement player;
    [SerializeField] public GameObject uiText;
    [SerializeField] AudioSource audioTeleportEffects;
    [SerializeField] AudioClip audioTeleport;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<player_Movement>();
    }
 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {

            player.transform.position = new Vector3(5.18f, 103.86f, -1.02f);
            uiText.SetActive(true);
            Invoke("Over", 5f);
            audioTeleportEffects.PlayOneShot(audioTeleport);
        }
    }
    void Over()
    {
        uiText.SetActive(false);
    }

}
