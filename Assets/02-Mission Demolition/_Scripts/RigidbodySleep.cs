﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof(Rigidbody))]

public class RigidbodySleep : MonoBehaviour
{
    private int sleepCountdown = 4; 

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (sleepCountdown > 0) {
            rigid.Sleep();
            sleepCountdown--;
        }
    }
}