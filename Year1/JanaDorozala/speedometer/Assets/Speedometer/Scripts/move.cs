using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    
    // most basic left and right movement

    public float speed = 2.0f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        if (moveX > 0 || moveX < 0)
        {
            rb.velocity = new Vector2(moveX * speed, 0) * Time.deltaTime;
            transform.localScale = new Vector2(moveX, 1);
        }
    }
}
