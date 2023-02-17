using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainCameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    public void SetPlayer()
    {
        player = GameObject.Find("Player");
        offset = new Vector3 (0,5,-5);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
