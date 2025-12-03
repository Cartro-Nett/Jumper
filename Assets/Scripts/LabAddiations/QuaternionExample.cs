using UnityEngine;

public class QuaternionExample : MonoBehaviour
{
    public float move;
    bool moving = true;
    
    // The lab exercise that would keep a smooth rotation of an object.
    // Added mine logic form the platfrom.y script just for the heart.
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(90.0f * Time.deltaTime,
        Vector3.up);
        if(CompareTag("Heart"))
        {
            if (moving)
            {
                transform.position += Vector3.up * Time.deltaTime;
                move -= Time.deltaTime;
                if (move <= 0)
                {
                    moving = false;
                }
            }
            else
            {
                transform.position -= Vector3.up * Time.deltaTime;
                move += Time.deltaTime;

                if (move >= 0.5)
                {
                    moving = true;
                }
            }
        }
      
    }
}
