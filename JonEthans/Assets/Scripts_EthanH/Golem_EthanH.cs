using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_EthanH : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject player;
    public Transform bulletPos;
    private float distance;
    public bool knockedBack = false;
    public float fireRate;
    public int health = 10;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(knockedBack == false)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        
        if(fireRate <= 0f)
        {
            if (distance > 5)
            {
                Fire();
            }
            fireRate = 2f;
        } else
        {
            fireRate -= Time.deltaTime;
        }

        

        if (health <= 0)
        {
            Destroy(gameObject);
            player.GetComponent<PlayerAttack_EthanH>().xp += 8;
            Debug.Log(player.GetComponent<PlayerAttack_EthanH>().xp);
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }

    public void knockback()
    {

    }

    private void Fire()
    {
        Instantiate(bulletPrefab, bulletPos.position, Quaternion.identity);
    }

}
