using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTreeScript : MonoBehaviour
{
    //Prefab for instantiating apples
    public GameObject applePrefab;
    //Speed at whcih the AppleTree moves
    public float speed = 1f;
    //Distance where AppleTree turns around 
    public float leftAndRightEdge = 20f;
    //Rate at which Apples will be instantiate 
    public float secondsBetweenAppleDrop;

    // Start is called before the first frame update
    void Start()
    {
        //Dropping apples every second
        Invoke( "DropApple", 2f);
    }

    void DropApple() {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrop);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //Changing direction
        if (pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed);//Move right
        }
        else if (pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed);//Move left
        }
    }

    void FixedUpdate()
    {
        //changing directions randomly
        //if (Random.value < chanceToChangeDirections) {
           // speed *= -1; //change direction
        //}
    }
}
