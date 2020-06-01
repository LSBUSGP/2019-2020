using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoad : MonoBehaviour
{
    public GameObject road;
    public GameObject Spawnpoint;
    // Start is called before the first frame update
    void Start()
    {
           // Instantiate(road, Spawnpoint.transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Instantiate(road, Spawnpoint.transform.position, Quaternion.identity);
            Debug.Log("MyTag");
        }
        //Instantiate(road, Spawnpoint.transform.position, Quaternion.identity);
        print("road");
      
    }

    
}
