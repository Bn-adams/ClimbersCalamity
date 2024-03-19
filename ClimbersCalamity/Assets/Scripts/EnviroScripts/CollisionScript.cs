using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    private GameObject player1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<P1Mov>().currentRespawn = transform.position;

            
        }
    }
}
