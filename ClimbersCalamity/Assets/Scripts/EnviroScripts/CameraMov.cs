using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMov : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    public float distanceBetweenPlayers;

    public Vector2 camPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1.transform.position.x > Player2.transform.position.x)
        {
            //distanceBetweenPlayers = Vector2.Distance(Player1, Player2);
         
        camPos = Player1.transform.position;
    }
}
