using UnityEngine;

public class Completed_Level : MonoBehaviour
{
    public GameManager GameManager;
    private bool isTriggered = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            GameManager.completedLevel();
        }
    }

}
