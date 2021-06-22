using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float turnspeed = 50.0f;
    public float speed = 30.0f;
    public float maxspeed = 40.0f;
    public float currentspeed;

    public bool GotItem = false;

    Rigidbody m_Rigidbody;

    


    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        GotItem = false;


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
        if (GotItem == true)
        {
            maxspeed = 70;
        }

       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            speed = 70.0f;
            GotItem = true;
            Invoke("RegularSpeed", 1);
        }
    }
    public void RegularSpeed()
    {
        speed = 30.0f;
        GotItem = false;
    }


}   


