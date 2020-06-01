using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovementController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float maxSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && rb.velocity.z < maxSpeed)
        {
            rb.velocity = new Vector3(0, 0, rb.velocity.z + 1);
        }
        else if (Input.GetMouseButton(1) && rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(0, 0, rb.velocity.z -1);
        }

    }
}
