using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Prindle_PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator anim;
    private float meleeSpeeed;
    [SerializeField] private float damage =10;
    public Prindle_PlayerLevel level;
    public GameObject player;
    float timeUntilMelee =0f;
    private float ultiTimer =1f;
    private float tacttTimer =1f;
    public GameObject scoreText;
    private Score score;
    AudioSource aud;
    public AudioClip hit, tact, ult;
    public XPManager_EthanH xp;
    public hitEnemy tactHit,bigTacthit,ultHit;
    public Boolean swung =false;
    Boolean attackPowerUp = false;
    Boolean gotAttackPowerup = false;
    float attackPowerUpDuration = 10;
    

    private void Start()
    {
        xp = player.GetComponent<XPManager_EthanH>();
        aud = GetComponent<AudioSource>();
        level = player.GetComponent<Prindle_PlayerLevel>();
        score = scoreText.GetComponent<Score>();
        
    }
   
    private void FixedUpdate()
    {
        if (attackPowerUp)
        {
            if(gotAttackPowerup == false)
            {
                damage += 5;
                gotAttackPowerup = true;
            }
            if(attackPowerUpDuration <= 0)
            {
                damage -= 5;
                attackPowerUp =false;
                attackPowerUpDuration = 10;
                gotAttackPowerup = false;
            }
            else
            {
                attackPowerUpDuration -= Time.deltaTime;
            }
        }
        
        if (timeUntilMelee <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                anim.SetTrigger("Attack");
                timeUntilMelee = level.weaponSpeed;
                print(timeUntilMelee);
                aud.clip = hit;
                swung = true;
            }
        }
        else
        {
            timeUntilMelee -= 1*Time.deltaTime;
            
        }
        if (tacttTimer <= 0)
        {
            if(Input.GetMouseButtonDown(1) && level.canTact == true)
            {
                tacttTimer = level.tactTimer;
                //print(tacttTimer);
                anim.SetTrigger("tact");
                aud.clip = tact;
                aud.Play();
            }
        }
        else
        {
            tacttTimer =- 1*Time.deltaTime;
            //print(tacttTimer);
            //print("what"+Time.deltaTime);
        }
        if (ultiTimer <= 0)
        {
            if(Input.GetKeyDown("e") && level.canUlt == true)
            {
                ultiTimer = level.ultTimer;
                anim.SetTrigger("ult");
                //print("eeee");
                aud.clip = ult;
                aud.Play();
            }
            
        }
        else
        {
            ultiTimer -= 1*Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ethan2_Enemy")
        {
            other.GetComponent<Prindle_Enemy>().TakeDamage(damage);
            other.GetComponent<Prindle_Enemy>().hammerStun(level.stunAmmount);
            score.playerscore += 35;
            //Debug.Log("Enemy Hit");
            if (swung)
            {
                aud.Play();
                swung = false;
            }
            
        }
        
        if (other.tag == "notEthan_Enemy" )
        {
            xp.GainXP(1);
            other.GetComponent<EnemyController_NotEthan>().TakeDamage(damage);
            score.playerscore += 5;
            //Debug.Log("Enemy Hit");
            if (swung)
            {
                aud.Play();
                swung = false;
            }
        }
        if (other.tag == "EthanH_Enemy")
        {
            other.GetComponent<Golem_EthanH>().takeDamage((int)damage);
            other.GetComponent<Golem_EthanH>().anim.SetTrigger("Hit");
            other.GetComponent<Golem_EthanH>().hammerStun(level.stunAmmount);
            score.playerscore += 15;
            //Debug.Log("Enemy Hit");
            if (swung)
            {
                aud.Play();
                swung = false;
            }
        }


        if (other.tag == "attackpowerup")
        {
            attackPowerUp = true;
            Destroy(other.gameObject);
            print("powered");
        }
    }
}
