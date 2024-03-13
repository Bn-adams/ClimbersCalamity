using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClimbingButtonsEvent : MonoBehaviour
{
    [Header("Players references and scripts")]
    public Collider2D playerCollider;
    public GameObject Checkpoint;
    
    public GameObject playerObject; // player object

    [Header("UI")]
    public GameObject panelPopUP;
    public Image FillerImageCrimp, FillerImageJug, FillerImagePinch, FillerImagePocket;

    //public Panel filler;

    [Header("Vectors")]
    public Vector3 UIOffset, newPanelPos;

    [Header("Inputs")]
    public KeyCode Crimp, Jug, Pinch, Pocket; // crimp, jug, pinch, pocket 

    [Header("Bools")]
    public bool isPanelPopUPActive;


    // Start is called before the first frame update
    void Start()
    { 
        panelPopUP.SetActive(false);
        UIOffset = new Vector3(-1, 1, 0);
        FillerImageCrimp.fillAmount = 0;
        FillerImageJug.fillAmount = 0;
        FillerImagePinch.fillAmount = 0;
        FillerImagePocket.fillAmount = 0;
        isPanelPopUPActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        ClimbingButtonUIPopUp();
    }

  

    public void OnTriggerStay2D(Collider2D collision) // checks for collision to bring up buttons UI
    {
        if (collision.name == "P1") // can probably change this later to a tag so that player 1 and player 2 have the same player tag and its more efficient
        {
            panelPopUP.SetActive(true);
            panelPopUP.transform.position = Checkpoint.transform.position + UIOffset;
            isPanelPopUPActive = true;
            //player1Move.enabled = false; USE THIS LATER TO SWITCH SCRIPTS
        }
        
    }
    public void ClimbingButtonUIPopUp()
    {
        if (isPanelPopUPActive == true && Input.GetKey(Crimp))
        {
            FillerImageCrimp.fillAmount += 2 * Time.deltaTime;
            if (FillerImageCrimp.fillAmount == 1)
            {
                Checkpoint.SetActive(false);
                panelPopUP.SetActive(false);
            }
        }
        else FillerImageCrimp.fillAmount -= 2 * Time.deltaTime;


        if (isPanelPopUPActive == true && Input.GetKey(Jug))
        {
            FillerImageJug.fillAmount += 2 * Time.deltaTime;
            if (FillerImageJug.fillAmount == 1)
            {
                Checkpoint.SetActive(false);
                panelPopUP.SetActive(false);
            }
        }
        else FillerImageJug.fillAmount -= 2 * Time.deltaTime;


        if (isPanelPopUPActive == true && Input.GetKey(Pinch))
        {
            FillerImagePinch.fillAmount += 2 * Time.deltaTime;
            if (FillerImagePinch.fillAmount == 1)
            {
                Checkpoint.SetActive(false);
                panelPopUP.SetActive(false);
            }
        }
        else FillerImagePinch.fillAmount -= 2 * Time.deltaTime;


        if (isPanelPopUPActive == true && Input.GetKey(Pocket))
        {
            FillerImagePocket.fillAmount += 2 * Time.deltaTime;
            if (FillerImagePocket.fillAmount == 1)
            {
                Checkpoint.SetActive(false);
                panelPopUP.SetActive(false);
            }
        }
        else FillerImagePocket.fillAmount -= 2 * Time.deltaTime;
    }
}
