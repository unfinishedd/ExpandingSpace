using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody ball;
    private float _lerpSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(ball.velocity, Vector3.up), Time.deltaTime * _lerpSpeed);
        transform.position = ball.transform.position + Vector3.up * Mathf.Sin(Time.deltaTime);
    }

    protected void OnDrawGizmos()
    {
        Gizmos.DrawLine(ball.transform.position, ball.transform.position + ball.velocity);
    }
}