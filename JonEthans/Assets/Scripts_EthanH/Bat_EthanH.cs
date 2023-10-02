using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Bat_EthanH : MonoBehaviour
{

    public int level = 0;
    private Rigidbody2D rb;
    private GameObject player;
    public float lifetime = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player_EthanH");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 axis = new Vector3(0, 0, 275);
        rb.transform.RotateAround(playerPosition, axis, Time.deltaTime * 100);
        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            Debug.Log("swing");
        }
    }
}
