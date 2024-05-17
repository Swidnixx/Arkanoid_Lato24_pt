using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pileczka : MonoBehaviour
{
    public float speed = 5;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 vel = new Vector3(Random.Range(-1.0f,1.0f), 1);
        Debug.Log(vel);
        vel.Normalize();
        rb.velocity = vel * speed;
    }
}
