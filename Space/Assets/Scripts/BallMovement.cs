using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float turnspeed = 50.0f;
    public float speed = 20.0f;


    Rigidbody m_Rigidbody;


    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float H = Input.GetAxisRaw("Horizontal");
        transform.eulerAngles += new Vector3(0, turnspeed * H, 0) * Time.deltaTime;
        m_Rigidbody.AddForce(transform.forward * Input.GetAxisRaw("Vertical") * speed);

        
    }
   
}   


