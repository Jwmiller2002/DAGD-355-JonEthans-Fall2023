using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EP_PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
   
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical"); 

        transform.position += new Vector3(h,v,0f) *speed *Time.deltaTime;
    }
}
