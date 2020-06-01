using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Generator : MonoBehaviour
{
    public GameObject platform;
    public Transform genPoint;
    public float distance;
    private float platformW;
    public float distanceMin;
    public float distanceMax;

    private int platformSelector;
    private float[] platformWidths;

    private float minHeight;
    public Transform heightMaxPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    public ObjectPooler[] objPools;

    //enemies
    public float randomEnemyThreshhold;
    private int enemySelector;
    public ObjectPooler[] enemyPool;

    void Start()
    {
        platformW = platform.GetComponent<BoxCollider2D>().size.x;

        platformWidths = new float[objPools.Length];
        minHeight = transform.position.y;
        maxHeight = heightMaxPoint.position.y;

        for(int i = 0; i < objPools.Length; i++)
        {
            platformWidths[i] = objPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }


    }

    void Update()
    {
        if (transform.position.x < genPoint.position.x)
        {
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }
            distance = Random.Range(distanceMin, distanceMax);

            platformSelector = Random.Range(0, objPools.Length);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distance, heightChange, transform.position.z);

            GameObject newPlatform = objPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), heightChange, transform.position.z);


            //enemies
            if (Random.Range(0f, 100f) < randomEnemyThreshhold)
            {
                enemySelector = Random.Range(0, enemyPool.Length);
                GameObject newEnemy = enemyPool[enemySelector].GetPooledObject();

                float enemyXPos = Random.Range(-platformWidths[platformSelector] + 2f, -0.7f);
                
                Vector3 enemyPos = new Vector3(enemyXPos, 3.5f, 0f);

                newEnemy.transform.position = transform.position + enemyPos;
                newEnemy.transform.rotation = transform.rotation;
                newEnemy.SetActive(true);
            }
        }
          
    }
}
