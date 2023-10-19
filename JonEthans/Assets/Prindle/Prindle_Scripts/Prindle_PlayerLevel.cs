using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prindle_PlayerLevel : MonoBehaviour
{
    [SerializeField] private float level=0;
    public float xpNeeded =10;
    public float xpmax =10;
    [SerializeField] private Animator anim;
    public Boolean canstun =false;
    public float stunAmmount;
    public float weaponSpeed=4;

    public Boolean canTact =false;
    public Boolean canUlt =false;

    public float tactTimer;
    public float ultTimer;

    public float ultSlow;
    public float tactStun;
    public Boolean ultBuff =false;
    public GameObject player;
    public XPManager_EthanH xp;
    // Update is called once per frame
    private void Start()
    {
        xp = player.GetComponent<XPManager_EthanH>();
        
    }
    void Update()
    {
        level = xp.level;
        if (Input.GetKeyDown("r") && level <10)
        {
            level += 1;
            print("d");
        }
        /*
        if(xpNeeded <= 0)
        {
            xpNeeded = xpmax * 2;
            xpmax = xpNeeded;
            level += 1;
            print("levelUP");
        }
        */
        print("current"+level);
        
        switch (level)
        {
            case 0:
                print("level0");
                weaponSpeed = 3.5f;
                break;
            case 1:
                print("level1");
                canTact = true;
                tactTimer = 8;
                tactStun = 3;
                
                break;
            case 2:
                print("level2");
                canstun = true;
                stunAmmount = 1;
                weaponSpeed =3f;
                break;
            case 3:
                canUlt = true;
                ultTimer = 12;
                ultSlow = 4;
                break;
            case 4:
                anim.SetBool("smoltact", false);
                break;
            case 5:
                tactStun = 6;
                break;
            case 6:
                ultBuff = true;
                ultTimer = 8;
                break;
            case 7:
                anim.SetBool("smallSwing", false);
                weaponSpeed = 2;
                break;
            case 8:
                tactTimer = 4;
                break;
            case 9:
                ultSlow = 8;
                //ult also stuns enemies
                break;
            case 10:
                ultTimer = 6;
                tactTimer = 3;
                canUlt = true;
                canTact = true;
                tactStun = 8;
                ultSlow = 10;
                weaponSpeed = 1f;
                print("MAX");
                break;
        }
    }
}
