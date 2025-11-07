using UnityEngine;

public class MovingPlatformX : MonoBehaviour
{
    public float move;
    bool moving = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.position += Vector3.right * Time.deltaTime;
            // Debug.Log("Pos");
            move -= Time.deltaTime;
            if (move <= 0)
            {
                moving = false;
            }
        }
        else
        {
            transform.position -= Vector3.right * Time.deltaTime;
            // Debug.Log("NEG");
            move += Time.deltaTime;

            if (move >= 5)
            {
                moving = true;
            }
        }
    }
}

