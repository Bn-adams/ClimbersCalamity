using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMovement : MonoBehaviour
{
    [Header("Players references and scripts")]
    public Collider2D playerCollider;
    public GameObject Checkpoint;
    public P1Mov player1Move; // player 1 movement script
    public GameObject playerObject; // player object

    [Header("UI")]
    public GameObject panelPopUP;
    //public Panel filler;

    [Header("Vectors")]
    public Vector3 UIOffset;
    public Vector3 newPanelPos;

    [Header("Inputs")]
    public KeyCode E;

    // Start is called before the first frame update
    void Start()
    {
        panelPopUP.SetActive(false);
        UIOffset = new Vector3(-1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "P1") // can probably change this later to a tag so that player 1 and player 2 have the same player tag and its more efficient
        {
            panelPopUP.SetActive(true);
            panelPopUP.transform.position = Checkpoint.transform.position + UIOffset;
            //player1Move.enabled = false; USE THIS LATER TO SWITCH SCRIPTS
            Debug.Log("collision with player");
        }
        if (Input.GetKey(E))
        {

        }


    }
}
