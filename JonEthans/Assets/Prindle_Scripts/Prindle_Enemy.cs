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

    public float fireRate;
    private float timeToFire;
    public float distanceToShoot = 5f;
    public float distanceToStop = 3f;
    public Transform firingPoint;
    public GameObject bulletPrefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeToFire = fireRate;
    }
    private void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTwardsTarget();
        }
        if(Vector2.Distance(target.position, transform.position) <= distanceToShoot)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if(timeToFire <= 0)
        {
            Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            Debug.Log("Shoot");
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
            if (Vector2.Distance(target.position, transform.position) >= distanceToStop)
            {
                rb.velocity = transform.up * speed *Time.deltaTime;
            }
            else
            {
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
        }
    }
}
