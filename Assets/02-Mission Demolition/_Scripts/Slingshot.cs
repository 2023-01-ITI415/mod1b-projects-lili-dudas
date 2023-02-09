using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject projectilePrefab;
    public float velocityMult = 10f;
    public GameObject projLinePrefab;

    [Header("Dynamic")]
    public GameObject launchPoint;

    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;

    void Awake(){
        Transform launchPointTrans = transform.Find("LauchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    void OnMouseEnter()
    {
        //print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true);
    }

    void OnMouseExit()
    {
        //print("Slingshot:OnMouseExit()");
        launchPoint.SetActive(false);
    }

    void OnMouseDown(){
        aimingMode = true;
        //Instantiate a projectile
        projectile = Instantiate(projectilePrefab) as GameObject;
        //start it at the launchPoint
        projectile.transform.position = launchPos;
        //set it to isKinematic for now
        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update(){
       //if slingshot is not in aimingMode, don't run this code
       if (!aimingMode) return;
       //get the current mouse position in 2D screen coordinates
       Vector3 mousePos2D = Input.mousePosition;
       mousePos2D.z = Camera.main.transform.position.z;
       Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
       //find the delta from launchPos to mousePos3D
       Vector3 mouseDelta = mousePos3D - launchPos;
       //limit mouseDelta to the radius of the Slingshot SphereCollider
       float maxMagnitude = this.GetComponent<SphereCollider>().radius;
       if (mouseDelta.magnitude > maxMagnitude) {
        mouseDelta.Normalize();
        mouseDelta *= maxMagnitude;
       }
       //move the projective to this new position
       Vector3 projPos = launchPos + mouseDelta;
       projectile.transform.position = projPos;

       if (Input.GetMouseButtonUp(0)){
          //mouse has been released
            aimingMode = false;
            Rigidbody projRB = projectile.GetComponent<Rigidbody>();
            projRB.isKinematic = false;
            projRB.collisionDetectionMode = CollisionDetectionMode.Continuous;
            projRB.velocity = -mouseDelta * velocityMult;
            FollowCam.POI = projectile; //set the _MainCamera POI
            //add ProjectileLine to the Projectile 
            Instantiate<GameObject>(projLinePrefab, projectile.transform);
            projectile = null;
       }

    }
}
