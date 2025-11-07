using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public Transform firePoint;
    float bulletForce = 5f;
    float charge = 0f;

    Cannon gun;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gun = GameObject.FindWithTag("Cannon").GetComponent<Cannon>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.T) && gun.hasPickUp)
        {
            charge += 1 * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.T) && gun.hasPickUp)
        {
            if (charge > 2.5f)
            {
                ChargeShot();
                Debug.Log("BigFire");
            }
            else
            {
                Debug.Log("Fire");
                shoot();
            }
        }
    }
    void shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody RB = bullet.GetComponent<Rigidbody>();
        if (RB != null)
        {
            RB.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        }
        charge = 0f;
    }
    void ChargeShot()
    {
        GameObject bullet2 = Instantiate(bulletPrefab2, firePoint.position, firePoint.rotation);

        Rigidbody RB2 = bullet2.GetComponent<Rigidbody>();
        if (RB2 != null)
        {
            RB2.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        }
        charge = 0f;
        
    }
}
