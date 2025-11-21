using UnityEngine;
using UnityEngine.UI;
public class MovePlayerAway : MonoBehaviour
{
    player_Movement player;
    [SerializeField] GameObject warningText;
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
        if(collision.CompareTag("Player"))
        {
            warningText.SetActive(true);
            player.transform.position = new Vector3(-3.09f, 0.369f, -2.83f);
            Invoke("hideText", 3f);
            audioTeleportEffects.PlayOneShot(audioTeleport);
        }
    }
    void hideText()
    {
        
        warningText.SetActive(false);   
    }
}
