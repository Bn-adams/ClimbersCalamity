using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class RespawnRope : MonoBehaviour
{
    public GameObject square;
    public GameObject ropeShooter;
    public P1Mov p1Mov;

    private SpringJoint2D rope;
    public int maxRopeFrameCount;
    private float lerpTime = 0.07f;
    private float ropedistance;

    public bool isRespawnSwinging = false;


    public LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Fallen(square.transform.position);
        }

        if (Input.GetKey(KeyCode.T)) 
        {
            DestroyRope();
        }


    }
    private void FixedUpdate()
    {
        //slowly lerps the player to the current anchor point which the current rope is connected to
        if (rope != null)
        {
            ropedistance = rope.distance;

            Debug.Log(ropedistance);
            //ropeShooter.transform.position = Vector3.Lerp(ropeShooter.transform.position, rope.connectedAnchor, t);


            rope.distance = rope.distance - lerpTime;

            Vector3 ropeAnchor = rope.connectedAnchor;
            Vector3 vectorDistance = ropeAnchor - ropeShooter.transform.position;
            float length = vectorDistance.magnitude;

            if (rope.distance <= 0.5)
            {
                //DestroyRope();
            }
        }
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

    void Fallen(Vector3 respawnPoint)
    {
        Vector3 playerpos = ropeShooter.transform.position;
        SpringJoint2D newRope = ropeShooter.AddComponent<SpringJoint2D>();
        newRope.enableCollision = false;
        newRope.frequency = 0.0f;
        newRope.connectedAnchor = respawnPoint;
        newRope.enabled = true;
        //newRope.distance = 10f;

        DestroyRope();
        rope = newRope;
        isRespawnSwinging = true;
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
                newRope.enableCollision = false;
                newRope.frequency = 0.0f;
                newRope.connectedAnchor = hit.point;
                newRope.enabled = true;

                DestroyRope();
                rope = newRope;
                isRespawnSwinging = true;
                
            }
        }
    }
    //destroys the game object rope and also turns of the bool that is used in the player mov script
    void DestroyRope()
    {
        isRespawnSwinging = false;
        GameObject.DestroyImmediate(rope);
    }
    
}
