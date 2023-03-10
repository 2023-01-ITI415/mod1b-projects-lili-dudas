using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class MazePlayer : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;

    private float movementX;
    private float movementY;

    PrototypeMaze pm;

    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody>();
        //winTextObject.SetActive(false);
    }
    
    void OnMove(InputValue movementValue)
    {
       Vector2 movementVector = movementValue.Get<Vector2>();

       movementX = movementVector.x;
       movementY = movementVector.y;
    }
    
    void FixedUpdate()
    {
        Vector3 movement =new Vector3(movementX, 0.0f , movementY);

        rb.AddForce(movement * speed);
    }
    
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            pm = FindObjectOfType<PrototypeMaze>();
            pm.SCORE_CHANGE();
        }
        
    }

}
