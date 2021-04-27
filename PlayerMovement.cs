using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement Instance;

    public float jumpHeight;
    public float speed;
    public float jumps;
    public float xMove;
    public float zMove;
    public float yMove;
    public float gravity;

    public int keys;

    public bool grounded;

    public KeyCode front;
    public KeyCode back;
    public KeyCode left;
    public KeyCode right;
    public KeyCode space;
    public KeyCode teleportKey;
    
    public CharacterController pilot;

    public Vector3 movement;
    public Vector3 gravMovement;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        keys = 0;
        grounded = pilot.isGrounded;
    }

    // Update is called once per frame
    void Update()
    {


        grounded = pilot.isGrounded;
        if(grounded && gravMovement.y < 0)
        {
            gravMovement.y = 0;
        }

        //forward and sideways movenemt
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        
        movement = transform.right * xMove + transform.forward* zMove;

        //update movenemt
        pilot.Move(movement * speed * Time.deltaTime);


        //jump and fall
        if (Input.GetKeyDown(space) && grounded)
        {
            gravMovement.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        gravMovement.y += gravity * Time.deltaTime;

        pilot.Move(gravMovement * Time.deltaTime);


        //Debug.Log("gravMovement.y: " + gravMovement.y + "\n");



    


    }

    //hit detection
    void OnControllerColliderHit(ControllerColliderHit hit)
    {

    }




}



