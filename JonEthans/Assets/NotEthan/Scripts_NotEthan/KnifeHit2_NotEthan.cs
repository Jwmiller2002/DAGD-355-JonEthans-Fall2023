using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHit2_NotEthan : MonoBehaviour
{
    public float damage;
    public float bleedChance;
    public float bleedRoll;
    public PlayerUltimate_NotEthan ultRef;
    public PlayerLevel_NotEthan levelRef;

    // Start is called before the first frame update
    void Start()
    {
        bleedChance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelRef.level == 5)
        {
            bleedChance = 3;
        }
        if (levelRef.level == 10)
        {
            bleedChance = 10;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController_NotEthan>().TakeDamage(damage*ultRef.damageMultiplier*levelRef.knifeNumber);
            bleedRoll = Random.Range(1, 10);
            if (bleedRoll <= bleedChance)
            {
                other.GetComponent<EnemyController_NotEthan>().bleedStacks++;
            }
            if (ultRef.isInvisible == true)
            {
                other.GetComponent<EnemyController_NotEthan>().bleedStacks++;
                ultRef.isInvisible = false;
            }
        }
    }
}
