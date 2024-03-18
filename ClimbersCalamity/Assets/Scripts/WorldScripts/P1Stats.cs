using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class P2Stats
{
    private float p2MovSpeed;

    public float P2MovSpeed { get =>  p2MovSpeed; set => p2MovSpeed = value; }
}

public class P1Stats : MonoBehaviour
{
    public float p1MovSpeed;
    public float p1AirSpeed;
    public float p1JumpHeight;
    public float p1AirFriction;

    public float gravity;

    public float p1Stamina;
    public float p1Stability;
    

    public int p1Lives;
    public int p1NumOfTradEquipment;
    public int p1NumOfChalk;
    public int p1ShoeType;
    public int p1CalamityScore;
    public int p1Multiplier;

    private void Start()
    {
        
    }

}


 



