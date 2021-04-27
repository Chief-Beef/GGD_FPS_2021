using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    public float maxHealth;

    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = healthBar.flexibleWidth;

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void PlayerDamage(float damage)
    {
        health -= damage;

        healthBar.rectTransform.sizeDelta = new Vector2(health, healthBar.flexibleHeight);
        healthBar.transform.position = new Vector2(this.transform.position.x - damage/2, this.transform.position.y);
    }

}
