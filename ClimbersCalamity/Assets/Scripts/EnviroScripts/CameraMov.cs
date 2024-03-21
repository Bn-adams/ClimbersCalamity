using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMov : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    public float distanceBetweenPlayers;

    public Vector3 camPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player2 != null)
        {
            distanceBetweenPlayers = Vector2.Distance(Player1.transform.position, Player2.transform.position);

            //if player 1 is rightmost 
            if (Player1.transform.position.x > Player2.transform.position.x)
            {
                camPos = new Vector3(Player2.transform.position.x + (distanceBetweenPlayers / 2), 0f, -10f);
            }

            //if player 2 is rightmost
            else if (Player1.transform.position.x < Player2.transform.position.x)
            {
                
                camPos = new Vector3(Player1.transform.position.x + (distanceBetweenPlayers / 2), 0f, -10f);
            }
            else
            {
                camPos.x = Player1.transform.position.x;
            }
            transform.position = camPos;
            
        }
        else
        {
            
            camPos = new Vector3(Player1.transform.position.x, 0f, -10f);
            transform.position = camPos;
        }
        
    }
}
