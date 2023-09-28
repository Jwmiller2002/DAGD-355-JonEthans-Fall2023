using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement_EthanH : MonoBehaviour
{
    public float speed = 500.0f;
    public float lifeTime = 10.0f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot(Vector2 direction)
    {
        rb.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
