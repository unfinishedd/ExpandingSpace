using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float turnspeed = 50.0f;
    public float speed;
    public float maxspeed = 40.0f;
    public float currentspeed;

    Rigidbody m_Rigidbody;


    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        //movement zelf
        float H = Input.GetAxisRaw("Horizontal");
        transform.eulerAngles += new Vector3(0, turnspeed * H, 0) * Time.deltaTime;
        m_Rigidbody.AddForce(transform.forward * Input.GetAxisRaw("Vertical") * speed);

        //current speed displayen in inspector
        currentspeed = m_Rigidbody.velocity.magnitude;

        //zorgen dat hij niet sneller gaat dan maxspeed
        if (m_Rigidbody.velocity.magnitude > maxspeed)
        {
            m_Rigidbody.velocity = m_Rigidbody.velocity.normalized * maxspeed;
        }

        //shift code        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            
            maxspeed = 50;
        }
        else
        {
            maxspeed = 40;
        }
    }
   
}   


