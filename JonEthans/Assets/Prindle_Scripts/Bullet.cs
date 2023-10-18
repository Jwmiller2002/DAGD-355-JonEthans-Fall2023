using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1,10)]
    public float bulletSpeed =30f;
    public Boolean isRocket =false;
    [SerializeField] float lifeTime =3F;
    private Rigidbody2D rb;
    //[SerializeField] private Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!isRocket)
        {
            Destroy(gameObject, lifeTime);
        }
        else
        {
            if(lifeTime <= 0)
            {
                //anim.settrigger("explosion")
                Destroy(gameObject);
            }
            else
            {
                lifeTime -= Time.deltaTime;
            }
        }
       
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.up * bulletSpeed;
    }
    
}
