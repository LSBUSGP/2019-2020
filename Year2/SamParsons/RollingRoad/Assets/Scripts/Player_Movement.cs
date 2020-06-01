using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Animator animator;

    public float jumpH;
    public float runSpeed;
    private float speedStore;
    public float speedMulti;

    public float speedIncMilestone;
    private float speedIncMilestoneStore;
    private float milestoneStore;
    private float speedMilestoneCount;

    public float jumpTime;
    private float jumpTimeCounter;

    private bool stoppedJumping;
    private bool canDoubleJump;

    private Rigidbody2D rb;
    public bool alive;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckR;

    public AudioSource audioS;
    public AudioClip sfPickSound;

    private Collider2D col;

    public GameManager gm;


    public Canvas canvasUI;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        jumpTimeCounter = jumpTime;
        alive = true;

        speedMilestoneCount = speedIncMilestone;

        speedIncMilestoneStore = speedIncMilestone;
        speedStore = runSpeed;
        milestoneStore = speedMilestoneCount;

        stoppedJumping = true;
        canDoubleJump = true;

        animator = GetComponent<Animator>();
        animator.SetBool("IsJumping", false);
    }

    
    void Update()
    {

        //grounded = Physics2D.IsTouchingLayers(col, whatIsGround);
        if (alive == true)
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckR, whatIsGround);

            if (transform.position.x > speedMilestoneCount)
            {
                speedMilestoneCount += speedIncMilestone;

                runSpeed = runSpeed * speedMulti;
                speedIncMilestone = speedIncMilestone * speedMulti;
            }
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("IsJumping", true);
                if (grounded)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpH);
                    stoppedJumping = false;
                    animator.SetBool("IsJumping", true);

                }

                if (!grounded && canDoubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpH);
                    canDoubleJump = false;
                    stoppedJumping = false;


                }
            }

            if (Input.GetKey(KeyCode.Space) && !stoppedJumping)
            {
                if (jumpTimeCounter > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpH);
                    jumpTimeCounter -= Time.deltaTime;
                    animator.SetBool("IsJumping", true);
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpTimeCounter = 0;
                stoppedJumping = true;

            }

            if (grounded)
            {
                jumpTimeCounter = jumpTime;
                canDoubleJump = true;
                animator.SetBool("IsJumping", false);
            }

        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "KillZone")
        {
            End();
           
        }
        if(other.gameObject.tag == "Enemy")
        {
            alive = false;
            animator.SetBool("Alive", false);
            rb.velocity = new Vector2 (0,0);
            rb.AddForce(new Vector2(-100f, 500f));
            col.enabled = false;
            StartCoroutine(DelayedEnd());
        }

        
    }

    public void PickUpClip()
    {
        audioS.clip = sfPickSound;
        audioS.Play();
        Debug.Log("pick");
        
    }

    IEnumerator DelayedEnd()
    {
        yield return new WaitForSeconds(1);
        End();
    }

    void End()
    {
        gm.restartGame();
        runSpeed = speedStore;
        speedMilestoneCount = milestoneStore;
        speedIncMilestone = speedIncMilestoneStore;
    }
}
