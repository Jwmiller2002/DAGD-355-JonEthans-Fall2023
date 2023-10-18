using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prindle_Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float health;
    public Transform target;
    public float speed;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    public float fireRate;
    private float timeToFire;
    public float distanceToShoot = 5f;
    public float distanceToStop = 3f;
    public Transform firingPoint;
    public GameObject bulletPrefab;

    public Prindle_PlayerLevel level;
    public GameObject player;

    private Boolean stunned = false;
    private Boolean slowed = false;

    public float xpGiven;

    private void Start()
    {
        GetTarget();
        player = GameObject.FindGameObjectWithTag("Player");
        level = player.GetComponent<Prindle_PlayerLevel>();
        rb = GetComponent<Rigidbody2D>();
        timeToFire = fireRate;
    }
    private void Update()
    {
        if (stunned)
        {
            timeToFire += level.tactStun;
            stunned = false;
        }
        if (slowed)
        {
            speed -= level.ultSlow;
            slowed = false;
        }
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTwardsTarget();
        }


        if (Vector2.Distance(target.position, transform.position) <= distanceToShoot)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if(timeToFire <= 0)
        {
            Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            
            timeToFire = fireRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {   if (target != null)
        {
            GetTarget();
            if (Vector2.Distance(target.position, transform.position) >= distanceToStop)
            {
                GetTarget();
                rb.velocity = transform.up * speed *Time.deltaTime;
            }
            else
            {
                GetTarget();
                rb.velocity = Vector2.zero;
            }
        }
    }
    private void RotateTwardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x)*Mathf.Rad2Deg -90f;
        Quaternion q = Quaternion.Euler(0,0,angle);
        transform.localRotation = Quaternion.Slerp(transform.localRotation,q,rotateSpeed);
    }
    private void GetTarget()
    {



        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("died");
            level.xpNeeded -= xpGiven;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            if (other.tag == "Ultimate")
            {
                slowed = true;
                if (level.ultBuff)
                {
                    stunned = true;
                }
                
            }
            if (other.tag == "Tacticle")
            {
                stunned = true;
            }
        }
    }
}
