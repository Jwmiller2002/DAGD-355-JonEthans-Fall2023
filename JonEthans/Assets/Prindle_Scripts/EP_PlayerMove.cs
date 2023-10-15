using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EP_PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator anim;
    public float speed;
    public float playerhurtdamage =5f;
    public float health = 20f;
    private Vector3 oldpos;
    private Vector2 mousePos;
    public GameObject player;
    public GameObject weapon;
    private Boolean isDead =false;
    
    
    // Update is called once per frame
    void Update()
    {
       
       
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical"); 
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y -transform.position.y, mousePos.x - transform.position.x) *Mathf.Rad2Deg -360f;
        //float hammerAngle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg + 222f;
        if (isDead == false)
        {
            transform.localRotation = Quaternion.Euler(0, 0, angle);
            //weapon.transform.localRotation = Quaternion.Euler(0, 0, hammerAngle);
            oldpos = transform.position;
            transform.position += new Vector3(h, v, 0f) * speed * Time.deltaTime;
        }
        else
        {
            print("GAME OVER");
        }
        if(oldpos != transform.position)
        {
            anim.SetBool("runing", true);
        }
        if(mousePos.x < player.transform.localPosition.x)
        {
            anim.SetBool("turnedLeft", true);
        }
        else
        {
            anim.SetBool("turnedLeft", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet") && isDead == false)
        {
            
            Destroy(other.gameObject);
            Debug.Log("Shot");
            health -= playerhurtdamage;
            anim.SetTrigger("hit");
            if (health <= 0)
            {
                anim.SetTrigger("Dead");
                anim.SetBool("isDead",true);
                isDead = true;
                //Destroy(gameObject);
                
            }
        }
    }
}
