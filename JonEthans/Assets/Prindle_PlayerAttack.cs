using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prindle_PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeeed;
    [SerializeField] private float damage;

    float timeUntilMelee;

    private void Update()
    {
        if(timeUntilMelee <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
                timeUntilMelee = meleeSpeeed;
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            //other.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log("Enemy Hit");
        }
    }
}
