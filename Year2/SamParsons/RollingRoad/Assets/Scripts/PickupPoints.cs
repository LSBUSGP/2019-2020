using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPoints : MonoBehaviour
{

    public float scoreToGive;
    public Distance theScoreManager;
    public GameObject pickUpEffect;
    public AudioClip pickUpSound;
    public AudioSource aSource;

    // Start is called before the first frame update
    void Start()
    {
        aSource.clip = pickUpSound;
        theScoreManager = FindObjectOfType<Distance>();
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            StartCoroutine(PickUp());
        }
    }
    IEnumerator PickUp()
    {
        aSource.clip = pickUpSound;
        aSource.Play();
        theScoreManager.sfScore += 1;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<ParticleSystem>().enableEmission = false;
        Instantiate(pickUpEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<ParticleSystem>().enableEmission = true;
    }
}
