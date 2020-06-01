using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Destroyer : MonoBehaviour
{
    public GameObject platformDestructionPoint;
    // Start is called before the first frame update
    void Start()
    {
        platformDestructionPoint = GameObject.Find("PlatformDestroyPoint");

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {

            gameObject.SetActive(false);
        }
    }
}
