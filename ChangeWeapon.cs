using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeapon : MonoBehaviour
{

    public int totalGuns;
    public int activeGun;


    public KeyCode switchGuns;


    public GameObject[] guns;
    public GameObject Uzi, Shotgun, Sniper;

    public Image[] crosshairs;
    public Image uziCross, shotgunCross, sniperCross;


    // Start is called before the first frame update
    void Start()
    {
        totalGuns = 3;

        activeGun = 0;
        guns = new GameObject[totalGuns];
        crosshairs = new Image[totalGuns];

        guns[0] = Uzi;
        guns[1] = Shotgun;
        guns[2] = Sniper;

        guns[0].SetActive(true);
        guns[1].SetActive(false);
        guns[2].SetActive(false);

        crosshairs[0] = uziCross;
        crosshairs[1] = shotgunCross;
        crosshairs[2] = sniperCross;

        crosshairs[0].enabled = true;
        crosshairs[1].enabled = false;
        crosshairs[2].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(switchGuns))
        {
            switchWeapon();
        }
    }



    public void switchWeapon()
    {

        //Switch Guns to the next gun
        //Switch Crosshairs to match the gun
        //Deactivate other guns and crosshairs

        Debug.Log("Switch Guns");

        //Changes ActiveGun to the next weapon and makes sure to stay inside array
        activeGun = (activeGun + 1) % totalGuns;

        for (int i = 0; i < totalGuns; i++)
        {
            if (i == activeGun)
            {
                //Set the chosen gun to active
                guns[i].SetActive(true);
                crosshairs[i].enabled = true;
            }
            else
            {
                //set all other guns to inactive
                guns[i].SetActive(false);
                crosshairs[i].enabled = false;
            }
        }

    }

}
