using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed, checkRadius;

    public bool hittingWall, notEdge, moveRight, jumpRight;

    [SerializeField]
    private Transform wallCheck;

    [SerializeField]
    private Transform edgeCheck;

    [SerializeField]
    private LayerMask whatIsWall;

    [SerializeField]
    private Rigidbody2D enemyRigidBody;

    // Use this for initialization
    void Start()
    {

    }

    private void FixedUpdate()
    {
        //Setd the hittingWall variable 
        hittingWall = Physics2D.OverlapCircle(wallCheck.position,
            checkRadius, whatIsWall);

        //Sets the notEdge vairable true or false based on the collision detected
        notEdge = Physics2D.OverlapCircle(edgeCheck.position,
            checkRadius, whatIsWall);

        if (hittingWall || notEdge)
            moveRight = !moveRight;

        if (moveRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
            enemyRigidBody.velocity = new Vector2(moveSpeed, enemyRigidBody.velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            enemyRigidBody.velocity = new Vector2(-moveSpeed, enemyRigidBody.velocity.y);
        }
    }



    // Update is called once per frame
    void Update()
    {

    }


}
