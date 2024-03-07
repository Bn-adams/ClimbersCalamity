using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    public GameObject ropeShooter;

    private SpringJoint2D rope;
    public int maxRopeFrameCount;
    private int ropeFrameCount;
    private int ropeMinLength = 1;
    private float lerpTime = 0.0001f;
    float t;

    public LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

        if(Input.GetMouseButtonDown(1))
        {
            GameObject.DestroyImmediate(rope);
        }

        

    }
    private void FixedUpdate()
    {

        if (rope != null)
        {
            ropeShooter.transform.position = Vector3.Lerp(ropeShooter.transform.position, rope.connectedAnchor, t);
            t = t + lerpTime;
            Vector3 ropeAnchor = rope.connectedAnchor;
            Vector3 vectorDistance = ropeAnchor - ropeShooter.transform.position;
            float length = vectorDistance.magnitude;
            if (length < ropeMinLength)
            {
                GameObject.DestroyImmediate(rope);
            }
        }


        /*
        if (rope != null)
        {
            ropeFrameCount++;
            if (ropeFrameCount > maxRopeFrameCount)
            {
                GameObject.Destroy(rope);
                ropeFrameCount = 0;
            }
        }
        */
    }

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
    
    
    

    void Fire()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 position = ropeShooter.transform.position;
        Vector3 direction = mousePosition - position;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, Mathf.Infinity);
        t = 0;

        if (hit.collider != null)
        {
            SpringJoint2D newRope = ropeShooter.AddComponent<SpringJoint2D>();
            newRope.enableCollision = false;
            newRope.frequency = 0.0f;
            newRope.connectedAnchor = hit.point;
            newRope.enabled = true;

            GameObject.DestroyImmediate(rope);
            rope = newRope;
            ropeFrameCount = 0;
        }


    }
}
