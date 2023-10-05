using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prindle_PlayerLevel : MonoBehaviour
{
    [SerializeField] private float level=1;
    public float xp;
    public float weaponDamage =5;
    public float weaponSpeed =5;
    public Boolean canTact =false;
    public Boolean canUlt =false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r") && level <10)
        {
            level += 1;
            print("d");
        }


        switch (level)
        {
            case 1:
                print("level1");
                break;
            case 2:
                print("level2");
                weaponDamage += 5;
                weaponSpeed += 5;
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                print("MAX");
                break;
        }
    }
}
