using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerAttack_EthanH : MonoBehaviour
{

    [SerializeField] private Animator anim;
    [SerializeField] private float attackSpeed;
    [SerializeField] private int damage;
    private float attackRate;

    // Update is called once per frame
    void Update()
    {
        if (attackRate <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
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
    }
}
