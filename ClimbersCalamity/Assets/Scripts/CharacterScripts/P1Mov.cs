using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P1Mov : MonoBehaviour
{
    [SerializeField]
    GameObject WorldStats;

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

        
    }

    void FixedUpdate()
    {
        Movement();
    }
    // Update is called once per frame
    void Update()
    {

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
    void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2 (moveHorizontal*p1stats.p1MovSpeed, moveVertical* p1stats.p1MovSpeed);
        
    }
}