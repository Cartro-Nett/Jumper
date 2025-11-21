using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public Transform firePoint;
    float bulletForce = 7f;
    float charge = 0f;
    bool inPowered = false;
    Cannon gun;
    [SerializeField] AudioSource audioShootEffects;
    [SerializeField] AudioClip[] shootEffects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gun = GameObject.FindWithTag("Cannon").GetComponent<Cannon>();
    }

    // Update is called once per frame
    void Update()
    {
        firePoint.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        if (Input.GetKey(KeyCode.T) && gun.hasPickUp)
        {
            charge += 1 * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.T) && gun.hasPickUp)
        {
            if (charge > 1f)
            {
                audioShootEffects.PlayOneShot(shootEffects[0]);
                ChargeShot();
                
            }
            else
            {
                if (inPowered == true)
                {
                    audioShootEffects.PlayOneShot(shootEffects[0]);
                    ChargeShot();
                }
                else
                {
                    audioShootEffects.PlayOneShot(shootEffects[1], 0.1f);
                    shoot();
                }
                
            }
        }
    }
    void shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody RB = bullet.GetComponent<Rigidbody>();
        if (RB != null)
        {
            RB.AddForce(Camera.main.transform.forward * bulletForce, ForceMode.Impulse);
        }
        charge = 0f;
    }
    void ChargeShot()
    {
        GameObject bullet2 = Instantiate(bulletPrefab2, firePoint.position, firePoint.rotation);

        Rigidbody RB2 = bullet2.GetComponent<Rigidbody>();
        if (RB2 != null)
        {
            RB2.AddForce(Camera.main.transform.forward * bulletForce, ForceMode.Impulse);
        }
        charge = 0f;
        
    }
    public void empowered()
    {
        inPowered = true;
    }
}
