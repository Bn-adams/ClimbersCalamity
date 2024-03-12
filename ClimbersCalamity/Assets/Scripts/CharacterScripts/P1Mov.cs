using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P1Mov : MonoBehaviour
{
    [SerializeField]
    GameObject WorldStats;
    public RopeScript ropeScript;

    public P1Stats p1stats;
    public P2Stats p2stats;
    private Rigidbody2D rb;

    

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

        //p2stats.P2MovSpeed = 1;

        //Debug.Log(p2stats.P2MovSpeed);

        if (p1stats != null)
        {
            p1stats.P1CalamityScore(1);
            Debug.Log(p1stats.p1CalamityScore);
            
        }
        else
        {
            Debug.Log("error");
        }
        

        Debug.Log("Start!!!" + p1score);

        //lastPlayerPosition = transform.position;
    }

    void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        var vel = rb.velocity;
        //Debug.Log(vel.magnitude);

        //PlayerDelta = transform.position - lastPlayerPosition;
        //lastPlayerPosition = transform.position;

        //Debug.Log(PlayerDelta);
        if (!ropeScript.isSwinging) { 

            Movement();
            //Debug.Log("Moving");
        }
        //called if you are swining
        else
        {
            //swingingVelocity = rb.velocity;
            Debug.Log("you swing boi");

            
        }
        
        //Debug.Log(p1stats.p1MovSpeed);
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
        //rb.velocity = swingingVelocity;
        //Debug.Log(swingingVelocity);
    }
    void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = 0;
        //Input.GetAxis("Vertical");
        //Vector2 v2v = rb.velocity;
        //Debug.Log(p1stats.p1MovSpeed);
        Vector2 Mov = new Vector2(moveHorizontal * 1, 0);
        //Debug.Log(rb.velocity);
        //rb.velocity += Mov;
        
    }
}
