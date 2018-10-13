﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    [SerializeField]
    private float accelerationForce, maxSpeed, jumpHeight, groundCheckRadius;

    //Respawn Delay
    [SerializeField]
    private float respawnDelay;

    private float moveInput;
    private bool jumpInput;

    //refresh the Jump button press state
    private bool jumpRelease;

    //Checkpoint Variable
    public Checkpoint currentCheckpoint;

    //Ground Establishment and Detection variables
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask whatIsGround;

    private bool grounded, doubleJumped;

    [SerializeField]
    private PhysicsMaterial2D playerMovingPM, playerStoppingPM;

    [SerializeField]
    private Animator anim;

    //Get RigidBody2D && Collider2D components on Start()
    private Rigidbody2D myRigidBody;    
    private Collider2D playerGroundCollider;

    // Bool to check if the player has respawned or not
    public bool Dead = false;

    // the number of lives that the player has remaining
    [SerializeField]
    public static int lives = 3;

    // Getter for remaining lives
    [SerializeField]
    public int RemainingLives { get { return lives; } }

    // the time it takes for the game to reset in seconds
    [SerializeField]
    private int RespawnTime = 2;

    [SerializeField]
    private AudioSource PlayerJump;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        playerGroundCollider = GetComponent<CapsuleCollider2D>();        
    }


    void FixedUpdate()
    {
        //Debug.Log(RemainingLives);
        UpdatePhysicsMaterial();
        Move();
        grounded = Physics2D.OverlapCircle(groundCheck.position,
            groundCheckRadius, whatIsGround);

        anim.SetFloat("jumpVelocity", myRigidBody.velocity.y);

        if (grounded)
        {
            doubleJumped = false;
        }        
    }


    // Update is called once per frame
    void Update()
    {
        GetMovementInput();

        //Send the player's speed to the animator to let it play the run animation
        anim.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x));
    }


    private void UpdatePhysicsMaterial()
    {
        if (Mathf.Abs(moveInput) > 0)
        {
            playerGroundCollider.sharedMaterial = playerMovingPM;
        }
        else
        {
            playerGroundCollider.sharedMaterial = playerStoppingPM;
        }
    }


    private void GetMovementInput()
    {
        //Movement Variables
        moveInput = Input.GetAxisRaw("Horizontal");
        jumpInput = Input.GetButtonDown("Jump");
        jumpRelease = Input.GetButtonUp("Jump");

        //Enables Jumping
        if (jumpInput && grounded)
        {
            Jump();
        }

        // Enables Double jumping
        if (jumpInput && !grounded && !doubleJumped)
        {
            DoubleJump();
        }
    }


    private void Move()
    {
        myRigidBody.AddForce(Vector2.right * moveInput * accelerationForce);

        Vector2 clampedVelocity = myRigidBody.velocity;

        clampedVelocity.x = Mathf.Clamp(myRigidBody.velocity.x, -maxSpeed, maxSpeed);

        myRigidBody.velocity = clampedVelocity;

        if (myRigidBody.velocity.x > 0.1)
            transform.localScale = new Vector3(1, 1, 1);
        else if (myRigidBody.velocity.x < -0.1)
            transform.localScale = new Vector3(-1, 1, 1);
    }


    private void Jump()
    {

        myRigidBody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        anim.SetFloat("jumpVelocity", myRigidBody.velocity.y);
            

        //Check for Second jump input to allow Double Jumping
        if (jumpInput && !doubleJumped && !grounded)
        {
            DoubleJump();
        }
    }


    private void DoubleJump()
    {
        //Changed from AddForce() due the double jump becoming unreliable and varying depending on when the player doubleJumps
        PlayerJump.Play();
        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpHeight);

        doubleJumped = true;
    }

    /* ***********************************************
     * For keeping the player on moving platforms
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }************************************/

    //----------------SETS CURRENT CHECKPOINT-----------
    public void SetCurrentCheckpoint(Checkpoint newCurrentCheckpoint)
    {        
        if (currentCheckpoint = null)
            currentCheckpoint.SetAsActivated(false);
        else
        {
            currentCheckpoint = newCurrentCheckpoint;
            newCurrentCheckpoint.SetAsActivated(true);
        }
    }
    

    public void Respawn()
    {
        --lives;
        StartCoroutine("RespawnDelay", RespawnTime);
        gameObject.SetActive(true);
    }

    public IEnumerator RespawnDelay(float time)
    {

        if (currentCheckpoint == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            myRigidBody.velocity = Vector2.zero;
            transform.position = currentCheckpoint.transform.position;
            gameObject.SetActive(false);
            yield return new WaitForSeconds(respawnDelay);
            

        }
    }
}