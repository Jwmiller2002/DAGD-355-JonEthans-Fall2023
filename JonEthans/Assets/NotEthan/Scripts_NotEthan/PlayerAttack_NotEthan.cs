using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAttack_NotEthan : MonoBehaviour
{

    [SerializeField] private Animator anim;

    [SerializeField] private float meleeSpeed;

    public AudioSource stab;

    float timeUntiMelee = .05f;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeUntiMelee <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
                timeUntiMelee = meleeSpeed;
                stab.Play();                      
            }
        }
        else
        {
            timeUntiMelee -= Time.deltaTime;
        }
    }


}
