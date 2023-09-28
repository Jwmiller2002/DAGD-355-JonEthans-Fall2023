using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 3f;
    //private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();
        //Rigidbody2D.AddForce(Vector2 force);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        transform.position += new Vector3(h, v, 0f) * playerSpeed * Time.deltaTime;
    }
}