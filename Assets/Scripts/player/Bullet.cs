using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 5;
    Vector3 direction = Vector3.forward;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
    void Moving()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        Destroy(gameObject, 3f);
    }
}
