using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyScript : MonoBehaviour
{

    public float speed;
    public float attackRange, sightRange;

    bool withinAttack, withinSight;

    public Vector3 areWeThereYet;

    //patrol variables
    public float patrolRange;
    bool destinationSet;
    public Vector3 destination;


    //attack variables
    public float shootTime;
    public float timerReset;
    public float attackValue;
    public float damageValue;
    public float rand;
    bool shoot;

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask groundMask, playerMask;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        timerReset = shootTime;
    }

    // Update is called once per frame
    void Update()
    {


        withinSight = Physics.CheckSphere(this.transform.position, sightRange, playerMask);
        withinAttack = Physics.CheckSphere(this.transform.position, attackRange, playerMask);


        if (withinSight && !withinAttack)
        {
            HotPursuit();
        }
        else if (withinAttack)
        {
            shootTime -= Time.deltaTime;
            Debug.Log("Attack");


            if (shootTime <= 0)
            {
                rand = Random.Range(0f, attackValue);
                if (rand <= 1.0f)
                {
                    Attack();
                }
                shootTime = timerReset;
            }
        }
        else
        {
            Patrol();
        }




    }


    public void Patrol()
    {
        if (!destinationSet)
        {
            setWalkPoint();
        }
        else
        {
            agent.SetDestination(destination);
        }

        areWeThereYet = this.transform.position - destination;

        if (areWeThereYet.magnitude < 2.0f)
        {
            destinationSet = false;
        }

    }

    public void Attack()
    {
        //agent.SetDestination(this.transform.position);
        this.transform.LookAt(player);

        PlayerHealth.Instance.PlayerDamage(damageValue);
        Debug.Log("BANG");

        shootTime = timerReset;
    }

    public void HotPursuit()
    {
        agent.SetDestination(player.position);
    }

    public void setWalkPoint()
    {

        float xPos = Random.Range(-patrolRange, patrolRange);
        float zPos = Random.Range(-patrolRange, patrolRange);

        destination = new Vector3(this.transform.position.x + xPos, this.transform.position.y, this.transform.position.z + zPos);

        if (Physics.Raycast(destination, -transform.up, 2f, groundMask))
        {
            destinationSet = true;
        }
    }

}