using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_EthanH : MonoBehaviour
{

    public Bat_EthanH batPrefab;
    private Rigidbody2D rb;
    public float speed = 5f;
    private float attackRate;
    public float startAttackRate = 0.3f;

    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }


        transform.position = pos;

        if(Input.GetKeyDown("e"))
        {
            for(int i = 0; i < 3; i++)
            {
                Vector3 spawnPoint = transform.position;
                Quaternion rotation = transform.rotation;
                Bat_EthanH bat = Instantiate(batPrefab, spawnPoint, rotation);
            }
        }

        if(attackRate <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemies_EthanH>().takeDamage(damage);
                }
            }

            attackRate = startAttackRate;
        }
        else
        {
            attackRate -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
