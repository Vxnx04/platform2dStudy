using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    public Rigidbody2D myRigidBody;
    public Vector2 velocity;
    public Vector2 friction = new Vector2 (.1f,0);
    public float speed = 5;
    public float speedRun = 10;
    public float forceJump = 2;
    private float _currentSpeed;


    void Update()
    {
       HandleMovement();
       HandleJump();
    }


 #region movement 
       private void HandleMovement(){

        if(Input.GetKey(KeyCode.LeftControl))
        _currentSpeed = speedRun;
        else
        _currentSpeed = speed;


         if(Input.GetKey(KeyCode.LeftArrow))
        {
         myRigidBody.velocity = new Vector2(-_currentSpeed, myRigidBody.velocity.y); 
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
         myRigidBody.velocity = new Vector2(+_currentSpeed, myRigidBody.velocity.y);    
        }

        if(myRigidBody.velocity.x > 0 )
        {
            myRigidBody.velocity += friction;
        }
        else if (myRigidBody.velocity.x < 0)
            myRigidBody.velocity -= friction;
        
    }
    #endregion


#region jump
    private void HandleJump()
    {
        if (Input.GetKey(KeyCode.Space))
        myRigidBody.velocity = Vector2.up * forceJump;
    }


#endregion
}
