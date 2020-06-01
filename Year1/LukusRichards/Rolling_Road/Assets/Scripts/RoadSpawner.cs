using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private GameObject currantPathEnd;
    [SerializeField] private GameObject[] paths;
    [SerializeField] private float[] nextPathProb;
    [SerializeField] private float spawnDistance = 50f;
    [SerializeField] private float movingPathSpeed = 10f;

    public Transform startLocation;

    // Optional AudioSource below
    // [SerializeField] private;

    private PlayerControls player;

    private List<GameObject> spawnedPathsList = new List<GameObject>();

    void Start()
    {
        spawnedPathsList.Add(currantPathEnd);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Path"))
        {
            Transform newSpawnPosition = currantPathEnd.transform.GetChild(0);
            GameObject newPath = Instantiate(paths[Random.Range(0, paths.Length)], 
                                                    newSpawnPosition.position + (Vector3.down * spawnDistance), 
                                                    Quaternion.identity);
            newPath.transform.forward = newSpawnPosition.forward;
            StartCoroutine(MovePath(newPath, newSpawnPosition.position));
            currantPathEnd = newPath;
            player.currentPath = newPath;

            spawnedPathsList.Add(currantPathEnd);
            if(spawnedPathsList.Count > 3)
            {
                Destroy(spawnedPathsList[0]);
                spawnedPathsList.RemoveAt(0);
            }
        }
    }

    private IEnumerator MovePath(GameObject path, Vector3 finalPosition)
    {
        bool connected = false;
        while (!connected)
        {
            path.transform.position = Vector3.Lerp(path.transform.position, finalPosition, movingPathSpeed * Time.deltaTime);
            if (Vector3.Distance(path.transform.position, finalPosition) < 0.5f)
            {
                connected = true;
                path.transform.position = finalPosition;
            }
            yield return null;
        }
    }
}
