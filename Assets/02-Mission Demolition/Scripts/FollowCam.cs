using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI; //static point of interest

    [Header("Dynamic")]
    public float camZ; //desired Z pos of the camera
    
    void Awake()
    {
        camZ = this.transform.position.z;
    }

    void FixedUpdate()
    {
        if (POI == null) return;
        //get the position of the poi
        Vector3 destination = POI.transform.position;
        //force destination.z to be camZ to keep the camera far enough away
        destination.z = camZ;
        //set camera to the destination
        transform.position = destination;
    }
}
