using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [SerializeField] int playerLife = 20;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 30f;

    public float playerspeed = 3f;
    public float shootingSpeed = 0.5f;

    readonly bool isShooting = true;

    public GameObject projectile;

    bool isAlive = true;
    bool jump = false;
    Rigidbody2D myRigidBody;
    Animator myAnimator;

    void Start()
    {
        
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        Attack();
        FlipSprite();

    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow *runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x),1f);
        }
    }

    private void Jump()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.G)) 
        { 
        myAnimator.SetBool("Attack", true);
            spawnProjectite();
        }
        else
        {
            myAnimator.SetBool("Attack", false);
        }
    }


    void spawnProjectite()
    {
        Instantiate(projectile, new Vector3(transform.position.x+ 0.5f, transform.position.y, transform.position.z), Quaternion.identity);
    }


}
