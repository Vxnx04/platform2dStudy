using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{ 
    public Rigidbody2D myRigidBody;
    [Header("Movement Setup")]
    public Vector2 velocity;
    public Vector2 friction = new Vector2 (.1f,0);
    public float speed = 5;
    public float speedRun = 10;
    public float forceJump = 2;
    private float _currentSpeed;
    private bool _isJumping = false;

    


    [Header("Feedback Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.5f;
    public Ease ease;
    public float animationTime = 0.3f;
    public SpriteRenderer rendererSprite;
    public Animator myAnimator;



    void Update()
    {
       HandleMovement();
       HandleJump();
    }


 #region movement 
       private void HandleMovement(){

        if(Input.GetKey(KeyCode.LeftControl))
        {
        _currentSpeed = speedRun;
            myAnimator.SetFloat("velocidade", 2f);
        }
        else
        {
        _currentSpeed = speed;
            myAnimator.SetFloat("velocidade", 0f);            
        }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
            myAnimator.ResetTrigger("Walking");
            myAnimator.SetFloat("velocidade", 0f);
            }
           if (Input.GetKeyUp(KeyCode.RightArrow))
            {
            myAnimator.ResetTrigger("Walking");
            myAnimator.SetFloat("velocidade", 0f);
            }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-_currentSpeed, myRigidBody.velocity.y);
            rendererSprite.flipX = true;
            myAnimator.SetTrigger("Walking");
            myAnimator.SetFloat("velocidade", 1f);
         
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(+_currentSpeed, myRigidBody.velocity.y);
            rendererSprite.flipX = false;
            myAnimator.SetTrigger("Walking");
            myAnimator.SetFloat("velocidade", 1f);


        }

        if (myRigidBody.velocity.x > 0 )
        {
            myRigidBody.velocity += friction;
        }
        else if (myRigidBody.velocity.x < 0)
            myRigidBody.velocity -= friction;
        
    }
    #endregion



    private void HandleJump()
    {
        if (Input.GetKey(KeyCode.Space) && !_isJumping)
        {
        StartCoroutine(JumpCoroutine());
        }
    }

    private void HandleScaleJump()
    {
        myRigidBody.transform.DOScaleY(jumpScaleY, animationTime).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidBody.transform.DOScaleX(jumpScaleX, animationTime).SetLoops(2, LoopType.Yoyo).SetEase(ease);
           }

    IEnumerator JumpCoroutine()
    {
        _isJumping = true;
        HandleScaleJump();
        myAnimator.SetBool("isJumping", true);
        myRigidBody.velocity = Vector2.up * forceJump;
         yield return new WaitForSeconds(0.7f);
         myRigidBody.transform.localScale = Vector2.one;
         DOTween.Kill(myRigidBody.transform);
        myAnimator.SetBool("isJumping", false);
        _isJumping = false;
    }
}
