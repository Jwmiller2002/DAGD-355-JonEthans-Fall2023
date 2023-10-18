using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHit2_NotEthan : MonoBehaviour
{
    public float damage = 1;
    public PlayerUltimate_NotEthan ultRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController_NotEthan>().TakeDamage(damage*ultRef.damageMultiplier);
            if (ultRef.isInvisible == true)
            {
                other.GetComponent<EnemyController_NotEthan>().bleedStacks++;
                ultRef.isInvisible = false;
            }
        }
    }
}
