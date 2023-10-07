using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_NotEthan : MonoBehaviour
{
    public float playerSpeed = 30f;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.position += new Vector3(h, v, 0f) * playerSpeed * Time.deltaTime;
    }
}
