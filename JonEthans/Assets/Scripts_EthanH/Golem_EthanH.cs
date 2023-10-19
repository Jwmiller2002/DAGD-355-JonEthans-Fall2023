using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_EthanH : MonoBehaviour
{

    [SerializeField] public Animator anim;
    public GameObject bulletPrefab;
    private GameObject player;
    public GameObject trail;
    public Transform bulletPos;
    private Rigidbody2D rb;
    private float distance;
    public float knockedBackCD;
    public float fireRate;
    public int health = 30;
    public float speed;

    float horizontalInput;
    float verticalInput;

    bool facingRight = true;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput > 0 && facingRight == false)
        {
            facingRight = true;
            anim.SetFloat("Move", 1f);
            //gameObject.transform.localScale = new Vector3(10, 10, 1);
        }
        else if (horizontalInput < 0 && facingRight == true)
        {
            facingRight = false;
            anim.SetFloat("Move", -1f);
            //gameObject.transform.localScale = new Vector3(-10, 10, 1);
        }

        if (knockedBackCD <= 0f)
        {
            rb.velocity = Vector2.zero;
            trail.GetComponent<TrailRenderer>().enabled = false;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);

            if (fireRate <= 0f)
            {
                if (distance > 5)
                {
                    Fire();
                }
                fireRate = 2f;
            }
            else
            {
                fireRate -= Time.deltaTime;
            }
        }
        else
        {
            knockedBackCD -= Time.deltaTime;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            player.GetComponent<XPManager_EthanH>().GainXP(8f);
            Debug.Log(player.GetComponent<PlayerAttack_EthanH>().xp);
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }

    public void knockback(float returnSpeed)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        trail.GetComponent<TrailRenderer>().enabled = true;
        rb.velocity = direction * returnSpeed;
    }

    private void Fire()
    {
        Instantiate(bulletPrefab, bulletPos.position, Quaternion.identity);
    }

}
