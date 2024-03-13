using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeMovemnt : MonoBehaviour
{
    [Header("Players references and scripts")]
    public Collider2D playerCollider;
    public GameObject ClipInGameObjectPanel;

    public GameObject ClipInObject; // player object

    [Header("UI")]
    public Image FillerImageClipIn;

    //public Panel filler;

    [Header("Vectors")]
    public Vector3 UIOffset, newPanelPos;

    [Header("Inputs")]
    public KeyCode ClipIn; // crimp, jug, pinch, pocket 

    [Header("Bools")]
    public bool isClipInPanelUp;
    public bool isClippedIn;

    // Start is called before the first frame update
    void Start()
    {
        isClipInPanelUp = false;
        ClipInGameObjectPanel.SetActive(false);
        UIOffset = new Vector3(-1, 1, 0);
        FillerImageClipIn.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ClipInCheck();
    }



    public void OnTriggerStay2D(Collider2D collision) // checks for collision to bring up buttons UI
    {
        if (collision.name == "P1") // can probably change this later to a tag so that player 1 and player 2 have the same player tag and its more efficient
        {
            ClipInGameObjectPanel.SetActive(true);
            ClipInGameObjectPanel.transform.position = ClipInObject.transform.position + UIOffset;
            isClipInPanelUp = true;
            //player1Move.enabled = false; USE THIS LATER TO SWITCH SCRIPTS
        }

    }
    

    public void ClipInCheck()
    {
        if (isClipInPanelUp == true && Input.GetKey(ClipIn))
        {
            FillerImageClipIn.fillAmount += 2 * Time.deltaTime;
            if(FillerImageClipIn.fillAmount == 1)
            {
                YouAreClippedIn();
            }
        }
        else FillerImageClipIn.fillAmount -= 2 * Time.deltaTime;
    }

    public void YouAreClippedIn()
    {
        Debug.Log("YOU ARE CLIPPED IN BITCH");
    }
}
