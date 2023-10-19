using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHit2_NotEthan : MonoBehaviour
{
    public int damage;
    public float bleedChance;
    public float bleedRoll;
    public PlayerUltimate_NotEthan ultRef;
    public  XPManager_EthanH levelRef;

    // Start is called before the first frame update
    void Start()
    {
        bleedChance = 0;
        damage = 3;
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
        if (other.tag == "notEthan_Enemy")
        {
            Debug.Log("Hit");
            other.GetComponent<EnemyController_NotEthan>().TakeDamage(damage * ultRef.damageMultiplier * levelRef.knifeNumber);
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
        else if (other.tag == "Ethan2_Enemy")
        {
            Debug.Log("Hit");
            other.GetComponent<Prindle_Enemy>().TakeDamage(damage * ultRef.damageMultiplier * levelRef.knifeNumber);
        }
        else if (other.tag == "EthanH_Enemy")
        {
            Debug.Log("Hit");
            other.GetComponent<Golem_EthanH>().takeDamage(damage * ultRef.damageMultiplier * levelRef.knifeNumber);
        }
    }
}
