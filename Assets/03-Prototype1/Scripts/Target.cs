using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Target : MonoBehaviour
{
    static public bool targetMet = false;
    void OnTriggerEnter(Collider other)
    {
        //when the trigger is hit by something
        MazePlayer plyr = other.GetComponent<MazePlayer>();
        if(plyr != null){
            //if so, get targetMet to  true
            Target.targetMet = true;
        }
    }
}
