using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthScript : MonoBehaviour
{

    public float health;

    public float maxHealth;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void takeDamage(float damage)
    {

        health -= damage;
        if(health <= 0)
        {
            //Die
            Destroy(this.gameObject);
        }

    }


}
