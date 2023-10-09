using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow_NotEthan : MonoBehaviour
{
    public GameObject Throwing_Knife;
    public Transform spawnPoint;
    public int knifeAmount = 3;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(2) && knifeAmount > 0)
        {
        
        Instantiate(Throwing_Knife,spawnPoint.position , spawnPoint.rotation);
            knifeAmount--;
        }
    }
}
