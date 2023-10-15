using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SearchService;

public class PlayerAttack_EthanH : MonoBehaviour
{

    [SerializeField] private Animator anim;
    [SerializeField] private float attackSpeed;
    [SerializeField] private int damage;
    private float attackRate;
    private float ultimateCD;
    public int level = 0;
    public int xp;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            level++;
            Debug.Log(level);
        }

        if (attackRate <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
                attackRate = 1;
            }
            else if (Input.GetMouseButtonDown(1) && level >= 4)
            {
                anim.SetTrigger("HAttack");
                attackRate = 1;
            }
            else if (Input.GetKeyDown(KeyCode.E) && ultimateCD <= 0f)
            {
                if(level >= 6)
                {
                    anim.SetTrigger("Ultimate");
                    attackRate = 11;
                    ultimateCD = 20f;
                }
                else if(level >= 3)
                {
                    anim.SetTrigger("Ultimate");
                    attackRate = 11;
                    ultimateCD = 30f;
                }
            }
        }
        else
        {
            attackRate -= Time.deltaTime;
        }

        ultimateCD -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if(level >= 7)
            {

            }
            else if(level >= 2)
            {

            }
            else
            {
                other.GetComponent<Enemies_EthanH>().takeDamage(damage);
            }
        }
        if (other.tag == "Bullet")
        {
            if(level >= 10)
            {

            }
            else if(level >= 8)
            {
                
            }
            else if(level >= 1)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
                other.GetComponent<BulletMovement_EthanH>().Deflect(direction);
            }
            else
            {
                Destroy(other.gameObject);
            }
            
        }
        if(other.tag == "Rocket")
        {
            if(level >= 5)
            {
                //Deflect()
            }
            else 
            { 
                Destroy(other.gameObject); 
            }
        }
    }
}
