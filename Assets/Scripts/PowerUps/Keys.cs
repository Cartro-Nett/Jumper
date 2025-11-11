using UnityEngine;

public class Keys : MonoBehaviour
{
    player_Movement player;
    public static int keyCollected = 0;
    private bool hasPickUp = false;
    [SerializeField] GameObject[] doors;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<player_Movement>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (hasPickUp)
        {
            return;
        }

        if (collision.CompareTag("Player"))
        {

            hasPickUp = true;
            keyCollected = keyCollected + 1;
            doors[0].SetActive(false);
            gameObject.SetActive(false);
            collectedKey();
            Debug.Log(keyCollected);
        }


    }
    void collectedKey()
    {
        if (keyCollected == 2)
        {
            doors[1].SetActive(false);
        }
    }
}
    
