using UnityEngine;

public class Cannon : MonoBehaviour
{
    PlayerShoot Player;
    public bool hasPickUp = false;
    public GameObject uiHelpers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<PlayerShoot>();
    }
    //Will let the player have the functions of shooting when they pick up the gun.
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            uiHelpers.SetActive(true);
            hasPickUp = true;
            gameObject.SetActive(false);
            Invoke("endOfHelp", 5f);
        }
    }
    void endOfHelp()
    {
        uiHelpers.SetActive(false);
    }
}
