using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;

    float v, h;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");

        Debug.DrawLine(transform.position, transform.position + new Vector3(rb.velocity.x * 10, rb.velocity.y * 10, 0), Color.green);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2((speed * h) * Time.deltaTime, (speed * v) * Time.deltaTime);
    }
}
