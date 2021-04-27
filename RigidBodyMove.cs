using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMove : MonoBehaviour
{

    public static RigidBodyMove Instance;

    public float xMove, zMove;
    public float jumpHeight;
    public float moveSpeed;
    public float jumpTimer;
    public float moveTimer;
    public float cast;
    public float height;
    public float radius;

    public Vector3 p1, p2;


    public Vector3 movement;
    public Vector3 yVelocity;
    public Vector3 moveDirection;

    public KeyCode jump;

    public Rigidbody rb;

    public CapsuleCollider cap;

    public bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
    

        if (Input.GetKeyDown(jump) && canJump)
        {
            rb.velocity = new Vector3(0, jumpHeight, 0);
            canJump = false;
        }


        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
    
        movement = (transform.right * xMove + transform.forward * zMove).normalized;
        
    }

    void FixedUpdate()
    {
        if (moveTimer <= 0 && !Caster())
        {
            Move();
        }
    }

    public void Move()
    {
        yVelocity = new Vector3(0, rb.velocity.y);
        rb.velocity = movement * moveSpeed * Time.deltaTime;
        rb.velocity += yVelocity;
    }
    
    private void OnCollisionEnter(Collision col)
    {

        if(col.gameObject.tag == "Platform")
        {
            canJump = true;
        }

    }


    public bool Caster()
    {
        RaycastHit hit;
        Vector3 p1 = transform.position + cap.center + Vector3.up * -cap.height /2.0f;
        Vector3 p2 = p1 + Vector3.up * cap.height;

        //return Physics.CapsuleCast(p1, p2, cap.radius, transform.forward, out hit, 1);
        return Physics.CapsuleCast(p1, p2, cap.radius, movement, out hit, 1);

    }

}
