using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerMovement_NotEthan : MonoBehaviour
{
    public float playerSpeed = 30f;
    private Rigidbody2D rb;

    bool facingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update is called once per second
    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.position += new Vector3(h, v, 0f) * playerSpeed * Time.deltaTime;

        if (h > 0 && facingRight == false)
        {
            facingRight = true;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (h < 0 && facingRight == true)
        {
            facingRight=false;
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }


}
