using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerMovement_NotEthan : MonoBehaviour
{
    public float playerSpeed = 30f;
    private Rigidbody2D rb;
    public Animator anim;
    public PlayerController_NotEthan playerController;

    float horizontalInput;
    float verticalInput;

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

        if (playerController.isDead == false)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            transform.position += new Vector3(horizontalInput, verticalInput, 0f) * playerSpeed * Time.deltaTime;
            anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
            anim.SetFloat("Speed", Mathf.Abs(verticalInput));
        }

            if (horizontalInput > 0 && facingRight == false)
            {
                facingRight = true;
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontalInput < 0 && facingRight == true)
            {
                facingRight = false;
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
        
    }


}
