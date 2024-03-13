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

    public P1Stats p1stats;
    public P2Stats p2stats;
    private Rigidbody2D rb;
    private bool isGrounded;
    

    int p1score = 0;

   

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

        p1stats.p1MovSpeed = 5;
        p1stats.p1JumpHeight = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ropeScript.isSwinging) { GroundMovement(); }

        

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
    }
    public void StrightAfterSwing()
    {
        rb.AddForce(transform.up * 200f);
    }

    
    void GroundMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * p1stats.p1MovSpeed, rb.velocity.y);

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
        if (Input.GetKey(KeyCode.Space) & isGrounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, p1stats.p1JumpHeight));
            isGrounded = false;
        }
    }
}
