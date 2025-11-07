 using UnityEngine;

public class cameraOnPlayer : MonoBehaviour
{
    public Transform player;
    public float followSpeed;
    public float followDistance;
    public Vector3 offset;
    public Quaternion rotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 pos = Vector3.Lerp(transform.position, player.position + -transform.forward * followDistance, followSpeed * Time.deltaTime);
            transform.position = pos;
            transform.rotation = rotation;
        }

    }
}
