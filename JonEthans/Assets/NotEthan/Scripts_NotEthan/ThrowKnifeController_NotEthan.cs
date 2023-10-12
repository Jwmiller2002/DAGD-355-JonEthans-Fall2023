using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowKnifeController_NotEthan : MonoBehaviour
{
    public float knifeSpeed;
    public Rigidbody2D rb;
    public float lifespan;
    public float damage = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * knifeSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController_NotEthan>().TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
