using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement_EthanH : MonoBehaviour
{

    private GameObject player;
    public bool firedFromEnemy;
    public bool enemyCollision = true;
    public float force = 500.0f;
    public float lifeTime = 10.0f;
    public float returnSpeed;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        //Level 8 idea if bool firedFromEnemy = true use code below else fire towards mouse
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void Deflect(Vector2 direction)
    {
        rb.velocity = direction * returnSpeed;
    }

    public void setTrajectory(Vector2 direction)
    {
        rb.AddForce(direction * force);
        Destroy(gameObject, lifeTime);
    }

    public void Split()
    {
        Vector2 position = transform.position;
        position += Random.insideUnitCircle * 0.5f;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        BulletMovement_EthanH split = Instantiate(this, position, transform.rotation);
        split.Deflect(direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthManager_EthanH>().TakeDamage(5f);
            //collision.gameObject.GetComponent<PlayerMovement_EthanH>().anim.SetTrigger("Hit");
            //Debug.Log("Oof");
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Enemy" )
        {
            collision.gameObject.GetComponent<Golem_EthanH>().health -= 5;
            collision.gameObject.GetComponent<Golem_EthanH>().anim.SetTrigger("Hit");
            //Debug.Log("Oof");
            Destroy(this.gameObject);
        }
    }
}
