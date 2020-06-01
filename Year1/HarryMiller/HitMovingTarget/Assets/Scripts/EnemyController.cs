using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject bullet;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timer++;

        if (timer >= 30)
        {
            timer = 0;
            Instantiate(bullet, transform.position, Quaternion.identity);
        }

    }
}
