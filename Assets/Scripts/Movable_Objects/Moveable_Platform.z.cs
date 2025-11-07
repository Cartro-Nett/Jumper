using UnityEngine;

public class Moveable_PlatformZ : MonoBehaviour
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
        //Vector3 mov = new Vector3(0f, 10f, 0f);
        //gameObject.transform.position = mov;

        
        if(moving)
        {
            
            transform.position += Vector3.forward * Time.deltaTime;
            move -= Time.deltaTime ;
            if (move <= 0)
            {
                moving = false;
            }
        }
        else 
        {
             transform.position -= Vector3.forward * Time.deltaTime;
             move += Time.deltaTime;

            if (move >= 5)
            {
                moving = true;
            }

        }
        
    }
    
}
