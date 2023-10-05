using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prindle_PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeeed;
    [SerializeField] private float damage;
    public Prindle_PlayerLevel level;
    float timeUntilMelee =0f;
    public float ultiTimer =0f;
    public float tacttTimer =0f;
    private void Update()
    {
        if(timeUntilMelee <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
                timeUntilMelee = level.weaponSpeed;
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }
        if (tacttTimer <= 0)
        {
            if(Input.GetMouseButtonDown(1) && level.canTact == true)
            {


                tacttTimer = level.tactTimer;
            }
        }
        else
        {
            tacttTimer =-Time.deltaTime;
        }
        if (ultiTimer <= 0)
        {
            if(Input.GetKeyDown("e") && level.canTact == true)
            {


                ultiTimer = level.ultTimer;
            }
        }
        else
        {
            ultiTimer -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Prindle_Enemy>().TakeDamage(level.weaponDamage);
            level.xpNeeded -= 35;
            Debug.Log("Enemy Hit");
            
        }
    }
}
