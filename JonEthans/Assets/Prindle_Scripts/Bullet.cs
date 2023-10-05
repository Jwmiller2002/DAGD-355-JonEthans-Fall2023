using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1,10)]
    public float bulletSpeed =30f;
    [Range(1, 10)]
    public float bulletDamage;
    private float lifeTime =3F;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.up * bulletSpeed;
    }
}
