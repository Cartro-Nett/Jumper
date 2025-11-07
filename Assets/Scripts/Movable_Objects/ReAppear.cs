using UnityEngine;
using System.Collections;
public class ReAppear : MonoBehaviour
{
    [SerializeField] GameObject platform1;
    [SerializeField] GameObject platform2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(PlatformCycle());
        StartCoroutine(PlatformCycle2());
    }
    private IEnumerator PlatformCycle()
    {

        while (true)
        {
            
            platform1.SetActive(true);
            yield return new WaitForSeconds(2f);

            platform1.SetActive(false);
            yield return new WaitForSeconds(1f);

            

        }
  
    }
    private IEnumerator PlatformCycle2()
    {
        while (true)
        {
            platform2.SetActive(true);
            yield return new WaitForSeconds(4f);

            platform2.SetActive(false);
            yield return new WaitForSeconds(1f);
        }
    }


}
