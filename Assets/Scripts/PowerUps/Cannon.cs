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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            uiHelpers.SetActive(true);
            hasPickUp = true;
            gameObject.SetActive(false);
        }
    }
}
