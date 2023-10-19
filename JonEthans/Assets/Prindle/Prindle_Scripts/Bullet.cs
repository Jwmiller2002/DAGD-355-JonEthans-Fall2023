using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1, 10)]
    public float bulletSpeed = 30f;
    public float returnSpeed;
    public Boolean isRocket = false;
    [SerializeField] float lifeTime = 3F;
    public Rigidbody2D rb;
    [SerializeField] private Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!isRocket)
        {
            Destroy(gameObject, lifeTime);
        }
        else
        {
            if (lifeTime <= 0)
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

    public void Deflect(Vector2 direction)
    {
        rb.velocity = direction * returnSpeed;
    }

    public void setTrajectory(Vector2 direction)
    {
        rb.AddForce(direction * bulletSpeed);
        Destroy(gameObject, lifeTime);
    }

    public void Split()
    {
        Vector2 position = transform.position;
        position += UnityEngine.Random.insideUnitCircle * 0.5f;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        Bullet split = Instantiate(this, position, transform.rotation);
        split.Deflect(direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthManager_EthanH>().TakeDamage(5f);
            //collision.gameObject.GetComponent<PlayerMovement_EthanH>().anim.SetTrigger("Hit");
            //Debug.Log("Oof");
            Destroy(this.gameObject);
        }

    }
}
