using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    public GameObject ropeShooter;
    public P1Mov p1Mov;

    private SpringJoint2D rope;
    public int maxRopeFrameCount;
    //private int ropeFrameCount;
    
    private float lerpTime = 0.07f;
    private float ropedistance;

    public bool isSwinging = false;
    public bool p1EnableCollision = true;
    public float p1Frequency = 0.0f;
    public float p1DampingRatio = 0.0f;




    public LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

        if(Input.GetMouseButtonDown(1) & isSwinging)
        {
            DestroyRope();
        }
        if (isSwinging)
        {
            
        }
        

    }
    private void FixedUpdate()
    {
        //slowly lerps the player to the current anchor point which the current rope is connected to
        if (rope != null)
        {
            ropedistance = rope.distance;

            //Debug.Log(ropedistance);
            //ropeShooter.transform.position = Vector3.Lerp(ropeShooter.transform.position, rope.connectedAnchor, t);
            

            rope.distance = rope.distance - lerpTime;

            Vector3 ropeAnchor = rope.connectedAnchor;
            Vector3 vectorDistance = ropeAnchor - ropeShooter.transform.position;
            float length = vectorDistance.magnitude;
            
            if (rope.distance <= 0.5)
            {
                DestroyRope();
            }
        }


        /*
        //makes the spawned rope have a timer where after the elapsed time the current rope will despawn
        if (rope != null)
        {
            ropeFrameCount++;
            if (ropeFrameCount > maxRopeFrameCount)
            {
                DestroyRope();
                ropeFrameCount = 0;
            }
        }
        */
    }


    //handes the render of the line trace so you can see it
    void LateUpdate()
    {
        if (rope != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, ropeShooter.transform.position);
            lineRenderer.SetPosition(1, rope.connectedAnchor);
            
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
    
    
    
    //Function is called everytime a new roap is trying to be spawned
    void Fire()
    {
        //calculates the position of where you want to swing too, casts a raytrace line and finds the
        //direction of the soon to be spawned rope

        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 position = ropeShooter.transform.position;
        Vector3 direction = mousePosition - position;

        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(position, direction, Mathf.Infinity);
 

        //ray trace cast is fired and all collision boxes it hits is stored in "hits" the for loop below 
        //compares each hit and finds if it has the tag "Swing" if it does that spawn the rope
        for (int i = 0; i < hits.Length; i++)
        {
            //Debug.Log(hits[i]);

            RaycastHit2D hit = hits[i];
            if (hit.transform.CompareTag("Swing"))
            {

                SpringJoint2D newRope = ropeShooter.AddComponent<SpringJoint2D>();
                newRope.enableCollision = true;
                newRope.frequency = p1Frequency;
                newRope.dampingRatio = p1DampingRatio;
                newRope.connectedAnchor = hit.point;
                newRope.enabled = true;


                //newRope.distance = 1;

                ReplaceRope();
                rope = newRope;
                isSwinging = true;
                //ropeFrameCount = 0;
            }
        }
    }
    //destroys the game object rope and also turns of the bool that is used in the player mov script
    void DestroyRope()
    {
        p1Mov = ropeShooter.GetComponent<P1Mov>();

        p1Mov.StrightAfterSwing();

        
        isSwinging = false;
        GameObject.DestroyImmediate(rope);
    }
    void ReplaceRope()
    {
        p1Mov = ropeShooter.GetComponent<P1Mov>();

        //p1Mov.StrightAfterSwing();


        isSwinging = false;
        GameObject.DestroyImmediate(rope);
    }
}
