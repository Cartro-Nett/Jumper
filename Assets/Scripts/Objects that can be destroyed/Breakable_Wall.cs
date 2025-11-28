using UnityEngine;

public class Breakable_Wall : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] public AudioSource audioSourceBreaking;
    [SerializeField] public AudioClip audioBreaking;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("BigBullet"))
        {
            audioSourceBreaking.PlayOneShot(audioBreaking);
            gameManager.addScore(10);
            Destroy(gameObject, 0.2f);
        }
    }
}
