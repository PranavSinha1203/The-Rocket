﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegastarScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, speed*Time.deltaTime);
    }


}
