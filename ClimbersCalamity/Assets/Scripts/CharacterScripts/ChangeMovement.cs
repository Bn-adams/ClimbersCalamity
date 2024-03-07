using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeMovement : MonoBehaviour
{
    [Header("Players references and scripts")]
    public Collider2D playerCollider;
    public GameObject Checkpoint;
    
    public GameObject playerObject; // player object

    [Header("UI")]
    public GameObject panelPopUP;
    public Image FillerImageE;
    public Image FillerImageR;
    public Image FillerImageT;
    public Image FillerImageY;
    //public Panel filler;

    [Header("Vectors")]
    public Vector3 UIOffset;
    public Vector3 newPanelPos;

    [Header("Inputs")]
    public KeyCode E;
    public KeyCode R;
    public KeyCode T;
    public KeyCode Y;

    [Header("Countdown")]
    public float UICountdownE = 2f;
    public float UICountdownR = 2f;
    public float UICountdownT = 2f;
    public float UICountdownY = 2f;

    [Header("Bools")]
    public bool isPanelPopUPActive;

    // Start is called before the first frame update
    void Start()
    {
        panelPopUP.SetActive(false);
        UIOffset = new Vector3(-1, 1, 0);
        FillerImageE.fillAmount = 0;
        FillerImageR.fillAmount = 0;
        FillerImageT.fillAmount = 0;
        FillerImageY.fillAmount = 0;
        isPanelPopUPActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkpointFiller();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "P1") // can probably change this later to a tag so that player 1 and player 2 have the same player tag and its more efficient
        {
            panelPopUP.SetActive(true);
            panelPopUP.transform.position = Checkpoint.transform.position + UIOffset;
            isPanelPopUPActive = true;
            //player1Move.enabled = false; USE THIS LATER TO SWITCH SCRIPTS
        }
        
    }
    public void checkpointFiller()
    {
        if (isPanelPopUPActive == true && Input.GetKey(E))
        {
            UICountdownE -= Time.deltaTime;
            FillerImageE.fillAmount += 2 * Time.deltaTime;
        }
        else FillerImageE.fillAmount -= 2 * Time.deltaTime;


        if (isPanelPopUPActive == true && Input.GetKey(R))
        {
            UICountdownR -= Time.deltaTime;
            FillerImageR.fillAmount += 2 * Time.deltaTime;
        }
        else FillerImageR.fillAmount -= 2 * Time.deltaTime;


        if (isPanelPopUPActive == true && Input.GetKey(T))
        {
            UICountdownT -= Time.deltaTime;
            FillerImageT.fillAmount += 2 * Time.deltaTime;
        }
        else FillerImageT.fillAmount -= 2 * Time.deltaTime;


        if (isPanelPopUPActive == true && Input.GetKey(Y))
        {
            UICountdownY -= Time.deltaTime;
            FillerImageY.fillAmount += 2 * Time.deltaTime;
        }
        else FillerImageY.fillAmount -= 2 * Time.deltaTime;
    }

    
}
