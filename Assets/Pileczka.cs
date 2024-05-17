using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pileczka : MonoBehaviour
{
    public float speed = 5;
    Rigidbody rb;

    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();

    }

    public void BallReady()
    {
        transform.position = startPos;
    }

    public void RunBall()
    {
        //Vector3 vel = new Vector3(Random.Range(-1.0f,1.0f), 1);
        Vector3 vel = new Vector3(0, 1);
        vel.Normalize();
        rb.velocity = vel * speed;
    }

    public void StopBall()
    {
        rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Deadly"))
        {
            StopBall();
            GameManager.Instance.Dead();
        }
    }
}
