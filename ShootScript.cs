using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour
{

    //Effect and Cause
    public float shotClock;

    public float range;
    public float damage;
    public float fireRate;
    public float reloadTimer;
    public float timerReset;
    public float ammo;
    public float magSize;

    public ParticleSystem muzzleFlash;

    public GameObject impactFlash;

    public Camera mainCam;

    public KeyCode R;

    public Text txt;

    public Transform reloadBar;

    public Image reloadWhite;
    public Image reloadBack;

    public float reloadPct;

    // Start is called before the first frame update
    void Start()
    {
        ammo = magSize;
        timerReset = reloadTimer;

        reloadWhite.enabled = false;
        reloadBack.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Uzi")
        {

            if (ammo < 10)
            {
                txt.text = "0" + ammo + "/" + magSize;
            }
            else
            {
                txt.text = ammo + "/" + magSize;
            }

        }
        else
        {
            txt.text = ammo + "/" + magSize;
        }


        if (shotClock >= 0)
        {
            shotClock -= Time.deltaTime;
        }
        
        if (Input.GetKeyDown(R))
        {
            ammo = 0;
            //PlayerHealth.Instance.PlayerDamage(10);
        }

        if (ammo == 0)
        {
            Reload();         
        }

        if (this.gameObject.tag == "Uzi")
        {
            if (Input.GetKey(KeyCode.Mouse0) && shotClock <= 0 && ammo > 0)
            {
                shoot();
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && shotClock <= 0 && ammo > 0)
            {
                shoot();
            }
        }

    }

    public void shoot()
    {

        muzzleFlash.Play();
        shotClock = 1f / fireRate;

        ammo--;

        //Shoot bullet
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            HealthScript target = hit.transform.GetComponent<HealthScript>();
            if (target != null)
            {
                target.hitMarker(damage);
            }
        }

        GameObject impact = Instantiate(impactFlash, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1.0f);
    }

    public void Reload()
    {

        reloadWhite.enabled = true;
        reloadBack.enabled = true;

        reloadTimer -= Time.deltaTime;

        if (reloadTimer <= 0)
        {
            ammo = magSize;
            reloadTimer = timerReset;

            reloadWhite.enabled = false;
            reloadBack.enabled = false;

        }

        reloadPct = (timerReset - reloadTimer)/timerReset;

        reloadBar.localScale = Vector3.Lerp(reloadBar.localScale, new Vector3(reloadPct, 1, 1), Time.deltaTime * 8f);


    }

}
