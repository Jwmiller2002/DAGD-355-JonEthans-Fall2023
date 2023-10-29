using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitEnemy : MonoBehaviour
{
    public Boolean abilHit =false;
    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //skelly and demon
        if (other.tag == "Ethan2_Enemy" && this.tag == "Tacticle")
        {
            print("abilityHit");
            abilHit = false;
            other.GetComponent<Prindle_Enemy>().abilityHit(abilHit);
        }
        if (other.tag == "Ethan2_Enemy" && this.tag =="Ultimate")
        {
            print("ULTHIT");
            abilHit = true;
            other.GetComponent<Prindle_Enemy>().abilityHit(abilHit);
        }
        //GolemStun
        if (other.tag == "EthanH_Enemy" && this.tag == "Tacticle")
        {
            print("abilityHit");
            abilHit = false;
            other.GetComponent<Prindle_Enemy>().abilityHit(abilHit);
        }
        if (other.tag == "EthanH_Enemy" && this.tag == "Ultimate")
        {
            print("ULTHIT");
            abilHit = true;
            other.GetComponent<Prindle_Enemy>().abilityHit(abilHit);
        }
    }
}
