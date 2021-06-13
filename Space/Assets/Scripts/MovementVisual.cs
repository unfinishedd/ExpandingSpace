using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementVisual : MonoBehaviour
{
    public Rigidbody ball;
    private float lerpSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(ball.velocity, Vector3.up), Time.deltaTime * lerpSpeed);
        transform.position = ball.transform.position + Vector3.up * Mathf.Sin(Time.deltaTime);
    }

    protected void OnDrawGizmos()
    {
        Gizmos.DrawLine(ball.transform.position, Vector3.up + ball.velocity);
    }
}