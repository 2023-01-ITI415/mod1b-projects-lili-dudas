﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI; //static point of interest
    [Header("Inscribed")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Dynamic")]
    public float camZ; //desired Z pos of the camera
    
    void Awake()
    {
        camZ = this.transform.position.z;
    }

    void FixedUpdate()
    {
        Vector3 destination = Vector3.zero;
        if (POI!=null){
            //if the POI has a rigidbody, check to see if it is sleeping
            Rigidbody poiRigid = POI.GetComponent<Rigidbody>();
            if ((poiRigid != null)&& poiRigid.IsSleeping()){
                POI = null;
            }
        }
        if (POI != null){
            destination = POI.transform.position;
        }
        destination.x = Mathf.Max(minXY.x,destination.x);
        destination.y = Mathf.Max(minXY.y,destination.y);
        destination = Vector3.Lerp(transform.position,destination, easing);
        //force destination.z to be camZ to keep the camera far enough away
        destination.z = camZ;
        //set camera to the destination
        transform.position = destination;
        //orthographicSize of the Camera to keep Ground in view
        Camera.main.orthographicSize = destination.y + 10;
    }
}
