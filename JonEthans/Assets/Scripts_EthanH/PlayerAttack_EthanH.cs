using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SearchService;

public class PlayerAttack_EthanH : MonoBehaviour
{

    [SerializeField] private Animator anim;
    [SerializeField] private float attackSpeed;
    [SerializeField] private int damage;
    private float attackRate;
    public int level = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            level++;
            Debug.Log(level);
        }

        if (attackRate <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
                attackRate = attackSpeed;
            } else if (Input.GetMouseButtonDown(1) && level >= 4)
            {
                anim.SetTrigger("RAttack");
                attackRate = attackSpeed;
            }
        }
        else
        {
            attackRate -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemies_EthanH>().takeDamage(damage);
        }
        if (other.tag == "Bullet")
        {
            if(level >= 8)
            {

            }
            else if(level >= 1)
            {
                other.GetComponent<BulletMovement_EthanH>().Deflect(transform.up);
            }
            else
            {
                Destroy(other.gameObject);
            }
            
        }
        if(other.tag == "Rocket")
        {
            if(level >= 5)
            {
                //Deflect()
            }
            else 
            { 
                Destroy(other.gameObject); 
            }
        }
    }
}
