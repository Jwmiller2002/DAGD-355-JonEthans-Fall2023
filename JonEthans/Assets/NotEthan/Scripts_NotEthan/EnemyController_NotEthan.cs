using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController_NotEthan : MonoBehaviour
{
    public ParticleSystem bleedEffect;
    public float bleedStacks = 0;
    public float enemyHealth = 2;
    float bleedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bleedStacks > 0)
        {
            Bleed();
            bleedParticle();
        }
        if (enemyHealth <= 0f)
        {
            //GetComponent<PlayerLevel_NotEthan>().exp += 2;
            Destroy(gameObject);
            
        }

    }

    public void Bleed()
    {
        float bleedDamage = 1;        
        bleedTime -= Time.deltaTime;
        if (bleedTime <= 0)
        {
            enemyHealth -= bleedDamage * bleedStacks;
            bleedTime = 10;
            bleedParticle();
        }
        
        
    }

    public void TakeDamage(float damage) 
    {
        enemyHealth -= damage;
    }

    void bleedParticle()
    {
        bleedEffect.Play();
    }
}
