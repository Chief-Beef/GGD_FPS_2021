using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth Instance;

    public float health;
    public float maxHealth;
    public float healthPct;
    public float healTimer;
    public float timerReset;

    public Transform healthBar;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        health = maxHealth;
        timerReset = healTimer;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(maxHealth + "\t" + health);
        HealthBar();

        if(health < maxHealth)
        {
            healTimer -= Time.deltaTime;
        }

        if(healTimer <= 0)
        {
            Heal();
        }
        
        if(health <= 0)
        {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneScript.Instance.LoadScene("Lose");
            
        }
    }


    public void PlayerDamage(float damage)
    {
        health -= damage;
        healTimer = timerReset;
    }

    public void HealthBar()
    {
        healthPct = health / maxHealth;

        healthBar.localScale = Vector3.Lerp(healthBar.localScale, new Vector3(healthPct, 1, 1), Time.deltaTime * 8f);
    }

    public void Heal()
    {
        if (health < maxHealth)
        {
            health++;
        }
    }


}
