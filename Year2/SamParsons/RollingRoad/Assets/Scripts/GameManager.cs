using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    AudioSource audioData;

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public Player_Movement thePlayer;
    private Vector3 playerStartPoint;

    private Platform_Destroyer[] platformList;

    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restartGame()
    {
        StartCoroutine("RestartGameCo");

    }

    public IEnumerator RestartGameCo()
    {

        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("EndScene");
    }

}
