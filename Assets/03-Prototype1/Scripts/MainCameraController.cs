using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainCameraController : MonoBehaviour
{
    private Vector3 offset;

    [Header("Inscribed")]
    public GameObject PLAYER;

    public void SetPlayer()
    {
        PLAYER = GameObject.Find("Player(Clone)");
        offset = new Vector3 (0,5,-5);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = PLAYER.transform.position + offset;
    }
}
