using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward * 10;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back * 10;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left * 10;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right * 10;
        }

        rb.velocity = direction;
    }
}
