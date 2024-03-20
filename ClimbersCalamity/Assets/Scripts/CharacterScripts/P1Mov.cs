using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class P1Mov : MonoBehaviour
{
    [SerializeField]
    GameObject WorldStats;
    public RopeScript ropeScript;
    public RespawnRope respawn;

    public P1Stats p1stats;
    public P2Stats p2stats;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float movement;
    float moveHorizontal;
    private Vector3 jumpVelocity = Vector3.zero;

    public Vector2 currentRespawn;

    int p1score = 0;

    public PhysicsMaterial2D friction;
    public PhysicsMaterial2D noFriction;

    public enum MovementPhase
    {
        Running,
        Swinging,
        Climbing,
        Falling
    }

    private void OnEnable()
    {
        p1score = PlayerPrefs.GetInt("score");
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("score", p1score);
    }

    void Start()
    {
        p1stats = WorldStats.GetComponent<P1Stats>();
        //p2stats = WorldStats.GetComponent<P2Stats>();
        rb = GetComponent<Rigidbody2D>();

        p1stats.p1MovSpeed = 10;
        p1stats.p1JumpHeight = 10f;
        p1stats.gravity = 20.0f;

        p1stats.p1AirSpeed = 0.5f;
        p1stats.p1AirFriction = 0.65f;

        //GameObject.Find("GroundTile").GetComponent<BoxCollider2D>().sharedMaterial = noFriction;
    }
    public void PhaseOfMovement(MovementPhase movementPhase)
    {
        switch (movementPhase)
        {
            case MovementPhase.Running:
                GroundMovement();
                break;
            case MovementPhase.Swinging:
                break;
            case MovementPhase.Climbing:
                break;
            case MovementPhase.Falling:
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        
        // If you're not swinging
        if (!ropeScript.isSwinging) {

            GroundMovement(); 
        }

        

        if (Input.GetKey(KeyCode.V))
        {
            p1score++;
            Debug.Log(p1score);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            OnDisable();
            SceneManager.LoadScene("SampleScene");
        }
        flip();
        //Debug.Log(currentRespawn);
    }
    public void StrightAfterSwing()
    {
        rb.AddForce(transform.up * 200f);
    }

    
    void GroundMovement()
    {
        GroundCheck();
        moveHorizontal = Input.GetAxis("Horizontal");
        movement = moveHorizontal * p1stats.p1MovSpeed;
        if (isGrounded)
        {
            rb.velocity = new Vector2(movement, rb.velocity.y);

            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(new Vector2(rb.velocity.x, p1stats.p1JumpHeight));
                isGrounded = false;
            }
        }
        else
        {
            movement = moveHorizontal * p1stats.p1AirSpeed;
            rb.AddForce(new Vector2(movement, 0));
            Debug.Log("airmove");
        }
        
        
    }
    void GroundCheck()
    {
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(transform.position, -transform.up, 0.6f);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];
            if (hit.transform.CompareTag("Ground"))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
    }

    void flip()
    {
        if(moveHorizontal < -0.01f) { transform.localScale = new Vector3(-1, 1, 1); }
        if (moveHorizontal > 0.01f) { transform.localScale = new Vector3(1, 1, 1); }
    }
    void p1Respawn()
    {

    }
    
}
