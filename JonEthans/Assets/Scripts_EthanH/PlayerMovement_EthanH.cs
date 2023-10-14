using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement_EthanH : MonoBehaviour
{
    
    [SerializeField] public Animator anim;
    private Rigidbody2D rb;
    public int health = 10;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 0)
        {
            Vector3 pos = transform.position;

            if (Input.GetKey("w"))
            {
                pos.y += speed * Time.deltaTime;
            }
            if (Input.GetKey("s"))
            {
                pos.y -= speed * Time.deltaTime;
            }
            if (Input.GetKey("d"))
            {
                pos.x += speed * Time.deltaTime;
                //anim walk right
                anim.SetFloat("Right", 1f);
            }
            if (Input.GetKeyUp("d"))
            {
                anim.SetFloat("Right", 0f);
                anim.SetTrigger("StopRight");
            }
            if (Input.GetKey("a"))
            {
                pos.x -= speed * Time.deltaTime;
                //anim walk left
                anim.SetFloat("Left", 1f);
            }
            if (Input.GetKeyUp("a"))
            {
                anim.SetFloat("Left", 0f);
                anim.SetTrigger("StopLeft");
            }


            transform.position = pos;
        }
        else
        {
            anim.SetTrigger("Dead");
        }
        
    }
}
