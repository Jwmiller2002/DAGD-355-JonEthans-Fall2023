using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AttackPowerup : MonoBehaviour
{

    GameObject player;
    private void Update()
    {
        Destroy(gameObject,10);
    }
   
}
