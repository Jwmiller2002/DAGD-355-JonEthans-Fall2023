using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Prindle_Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float health;
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
    public GameObject trail;
    public float knockedBackCD;
    public XPManager_EthanH xp;
    public Prindle_PlayerLevel level;
    public GameObject player;

    private Boolean stunned = false;
    private Boolean slowed = false;

    public float xpGiven;
    public GameObject Dagger_Pickup;
    public GameObject Bread_Pickup;
    public GameObject Grind_Pickup;

    private void Start()
    {
        GetTarget();
        player = GameObject.FindGameObjectWithTag("Player");
        level = player.GetComponent<Prindle_PlayerLevel>();
        rb = GetComponent<Rigidbody2D>();
        xp = player.GetComponent<XPManager_EthanH>();

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
        


        if (Vector2.Distance(target.position, transform.position) <= distanceToShoot)
        {
            Shoot();
        }

        if(knockedBackCD <= 0) trail.GetComponent<TrailRenderer>().enabled = false;
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
            print("hasTarget");
            GetTarget();
            if (Vector2.Distance(target.position, transform.position) >= distanceToStop)
            {
                GetTarget();
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                print("hasTargetNMOVE");
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
            xp.GainXP(xpGiven);
            float itemChance = Random.Range(0, 20);
            player.GetComponent<XPManager_EthanH>().GainXP(1f);
            if (itemChance <= 1)
            {
                int item = Random.Range(0, 2);
                if (item == 0)
                {
                    Instantiate(Dagger_Pickup, transform.position, Quaternion.identity);
                }
                if (item == 1)
                {
                    Instantiate(Bread_Pickup, transform.position, Quaternion.identity);
                }
                if (item == 2)
                {
                    Instantiate(Grind_Pickup, transform.position, Quaternion.identity);
                }

            }
        }
    }

    public void hammerStun(float stun)
    {
        timeToFire += stun;
    }

    public void knockback(float returnSpeed)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        trail.GetComponent<TrailRenderer>().enabled = true;
        rb.velocity = direction * returnSpeed;
    }

    private void OnParticleCollision(GameObject other)
    {
        print("playernotother");
        if (other.tag == "Ultimate")
        {
            print("ultTTTT");
            slowed = true;
            if (level.ultBuff)
            {
                stunned = true;
            }

        }
        if (other.tag == "player")
        {
            print("playernotother");
            if (other.tag == "Ultimate")
            {
                print("ult");
                slowed = true;
                if (level.ultBuff)
                {
                    stunned = true;
                }
                
            }
            if (other.tag == "Tacticle")
            {
                print("tact");
                stunned = true;
            }
        }
    }
}
