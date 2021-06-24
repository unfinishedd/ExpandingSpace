using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //movement
    public float turnspeed = 50.0f;
    public float speed = 30.0f;
    public float maxspeed = 40.0f;
    public float currentspeed;

    //powerup
    public bool GotItem = false;

    //rigidbody
    Rigidbody m_Rigidbody;

    //particles
    public ParticleSystem ps1;
    public ParticleSystem ps2;
    public ParticleSystem ps3;
    public ParticleSystem ps4;
    private ParticleSystem.MainModule pMain1;
    private ParticleSystem.MainModule pMain2;
    private ParticleSystem.MainModule pMain3;
    private ParticleSystem.MainModule pMain4;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        GotItem = false;
        pMain1 = ps1.main;
        pMain2 = ps2.main;
        pMain3 = ps3.main;
        pMain4 = ps4.main;
        //ps.main.startSize = new ParticleSystem.MinMaxCurve(minFloat, maxFloat);



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
    //powerup code
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            BoostParticleEffect();
            speed = 70.0f;
            GotItem = true;
            Invoke("RegularSpeed", 1);

        }
    }
    public void RegularSpeed()
    {
        speed = 30.0f;
        GotItem = false;
        NormalEffects();
    }
    public void BoostParticleEffect()
    {
        FindObjectOfType<SoundManagerScript>().PlayPowerupSound();
        //speed
        pMain1.startSpeed = 14f;
        pMain2.startSpeed = 14f;
        pMain3.startSpeed = 14f;
        pMain4.startSpeed = 14f;
        //lifetime
        pMain1.startLifetime = 0.5f;
        pMain2.startLifetime = 0.5f;
        pMain3.startLifetime = 0.5f;
        pMain4.startLifetime = 0.5f;
    }
    public void NormalEffects()
    {
        //speed
        pMain1.startSpeed = 7f;
        pMain2.startSpeed = 7f;
        pMain3.startSpeed = 7f;
        pMain4.startSpeed = 7f;
        //lifetime
        pMain1.startLifetime = 0.2f;
        pMain2.startLifetime = 0.2f;
        pMain3.startLifetime = 0.2f;
        pMain4.startLifetime = 0.2f;

    }


}   


