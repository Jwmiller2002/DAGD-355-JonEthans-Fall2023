using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prindle_PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeeed;
    [SerializeField] private float damage =10;
    public Prindle_PlayerLevel level;
    public GameObject player;
    float timeUntilMelee =0f;
    public float ultiTimer =0f;
    public float tacttTimer =0f;
    public GameObject scoreText;
    private Score score;
    AudioSource aud;
    public AudioClip hit, tact, ult;
    public XPManager_EthanH xp;
    
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
    private void Update()
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
                
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }
        if (tacttTimer <= 0)
        {
            if(Input.GetMouseButtonDown(1) && level.canTact == true)
            {
                tacttTimer = level.tactTimer;
                anim.SetTrigger("tact");
                aud.clip = tact;
                aud.Play();
            }
        }
        else
        {
            tacttTimer =-Time.deltaTime;
        }
        if (ultiTimer <= 0)
        {
            if(Input.GetKeyDown("e") && level.canUlt == true)
            {
                ultiTimer = level.ultTimer;
                anim.SetTrigger("ult");
                print("eeee");
                aud.clip = ult;
                aud.Play();
            }
        }
        else
        {
            ultiTimer -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Prindle_Enemy>().TakeDamage(damage);
            
            score.playerscore += 35;
            Debug.Log("Enemy Hit");
            aud.Play();
        }
        if (other.tag == "notEthan_Enemy")
        {
            xp.GainXP(1);
            other.GetComponent<EnemyController_NotEthan>().TakeDamage(damage);
            score.playerscore += 15;
            Debug.Log("Enemy Hit");
            aud.Play();
        }
        if (other.tag == "EthanH_Enemy")
        {
            other.GetComponent<Golem_EthanH>().takeDamage((int)damage);
            other.GetComponent<Golem_EthanH>().anim.SetTrigger("Hit");
            score.playerscore += 15;
            Debug.Log("Enemy Hit");
            aud.Play();
        }


        if (other.tag == "attackpowerup")
        {
            attackPowerUp = true;
            Destroy(other.gameObject);
            print("powered");
        }
    }
}
