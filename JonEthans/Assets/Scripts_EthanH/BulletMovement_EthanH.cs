using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement_EthanH : MonoBehaviour
{

    private GameObject player;
    public float force = 500.0f;
    public float lifeTime = 10.0f;
    public float returnSpeed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
