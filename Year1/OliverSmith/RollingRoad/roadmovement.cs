using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadmovement : MonoBehaviour
{
    public int movespeed = 1;
    public Vector3 userDirection = Vector3.forward;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0, 0, -Time.deltaTime);
        transform.Translate(userDirection * movespeed * Time.deltaTime);
    }
}
