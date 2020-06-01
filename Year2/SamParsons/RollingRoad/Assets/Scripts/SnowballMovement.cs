using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballMovement : MonoBehaviour
{
    private Player_Movement playerSpeed;
    //public float speed;
    public int damage = 40;
    public float runSpeed;
    public Rigidbody2D rb;
    public Collider2D col;
    public GameObject hitEffect;
    public AudioClip audioC;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
         var run = GameObject.Find("Player").GetComponent<Player_Movement>();
         runSpeed = run.runSpeed;
         rb.velocity = transform.right * runSpeed * 2;
        

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.gameObject.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(audioC, this.gameObject.transform.position);
            Destroy(gameObject);
            collision.gameObject.SetActive(false);
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
        if (collision.gameObject.tag == "Platform")
        {
            AudioSource.PlayClipAtPoint(audioC, this.gameObject.transform.position);
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
        
    }
}
