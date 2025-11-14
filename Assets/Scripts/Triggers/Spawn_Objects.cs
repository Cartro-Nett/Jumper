using UnityEngine;

public class Spawn_Objects : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    player_Movement player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger!");
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(true);
            }
            Invoke("getRid", 3f);
        }
    }
    void getRid()
    {
        gameObject.SetActive(false);
    }
}
