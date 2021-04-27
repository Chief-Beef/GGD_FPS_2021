using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootScript : MonoBehaviour
{

    //Effect and Cause
    public float shotClock;

    public float range;
    public float damage;
    public float fireRate;

    public ParticleSystem muzzleFlash;

    public GameObject impactFlash;

    public Camera mainCam;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (shotClock >= 0)
        {
            shotClock -= Time.deltaTime;
        }

        if (this.gameObject.tag == "Uzi")
        {
            if (Input.GetKey(KeyCode.Mouse0) && shotClock <= 0)
            {
                shoot();
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && shotClock <= 0)
            {
                shoot();
            }
        }

    }

    public void shoot()
    {

        muzzleFlash.Play();
        shotClock = 1f / fireRate;

        //Shoot bullet
        RaycastHit hit;

        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            HealthScript target = hit.transform.GetComponent<HealthScript>();
            if(target != null)
            {
                target.hitMarker(damage);
            }
        }

        GameObject impact = Instantiate(impactFlash, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1.0f);
    }



}
