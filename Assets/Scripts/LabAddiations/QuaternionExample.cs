using UnityEngine;

public class QuaternionExample : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(90.0f * Time.deltaTime,
        Vector3.up);
    }
}
