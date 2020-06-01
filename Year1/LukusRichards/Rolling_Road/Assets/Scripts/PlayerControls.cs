using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    Rigidbody rb;

    public float moveSpeed = 5;

    public GameObject currentPath;

    public bool movingLeft;
    public bool movingRight;
    public bool movingUp;
    public bool movingDown;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();

       // movingUp = true;
      //  movingDown = false;
      //  movingLeft = false;
      //  movingRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        DirecTerms();
    }

    void DirecTerms()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
           // movingLeft = true;

            transform.Translate(Time.deltaTime * -moveSpeed, 0, 0);

           // movingUp = false;
           // movingDown = false;
           // movingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movingRight = true;

           transform.Translate(moveSpeed * Time.deltaTime, 0, 0);

           // movingUp = false;
           // movingDown = false;
          //  movingLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
          //  movingUp = true;

            transform.Translate(0, 0, moveSpeed * Time.deltaTime);

          //  movingDown = false;
          //  movingLeft = false;
         //   movingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
           // movingDown = true;

            transform.Translate(0, 0, -moveSpeed * Time.deltaTime);

           // movingLeft = false;
          //  movingRight = false;
          //  movingUp = false;
        }
    }
}
