using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prindle_PlayerLevel : MonoBehaviour
{
    [SerializeField] private float level=0;
    public float xpNeeded =50;
    public float xpmax =50;

    
    public float weaponSpeed=4;

    public Boolean canTact =false;
    public Boolean canUlt =false;

    public float tactTimer;
    public float ultTimer;

    public float ultSlow;
    public float tactStun;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r") && level <10)
        {
            level += 1;
            print("d");
        }
        if(xpNeeded <= 0)
        {
            xpNeeded = xpmax * 2;
            xpmax = xpNeeded;
            level += 1;
            print("levelUP");
        }

        switch (level)
        {
            case 0:
                print("level0");
                weaponSpeed = 4f;
                break;
            case 1:

                print("level1");
                canTact = true;
                tactTimer = 8;
                
                break;
            case 2:
                print("level2");
                
                weaponSpeed =1.5f;
                break;
            case 3:
                canUlt = true;
                ultTimer = 12;
                break;
            case 4:
                //upgrade Heavy size
                break;
            case 5:
                // heavy damage and slow
                break;
            case 6:
                ultTimer = 8;
                break;
            case 7:
                
                weaponSpeed = 1;
                break;
            case 8:
                tactTimer = 4;
                break;
            case 9:
                //ult slows and does more damage to enemies
                break;
            case 10:
                ultTimer = 6;
                tactTimer = 3;
                
                weaponSpeed = 0.5f;
                print("MAX");
                break;
        }
    }
}
