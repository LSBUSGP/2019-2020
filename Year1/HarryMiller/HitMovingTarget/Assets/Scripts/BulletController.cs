using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    Vector2 playerVelocity;        //Vx and Vy
    Vector2 playerStartPos;        //Ax and Ay
    Vector2 shooterPos;            //Tx and Ty
    public float projectileSpeed;  //s
    float timeToHit;               //t
    
    Vector2 collisionPoint;        //x and y

    Rigidbody2D rb;
    GameObject[] targets;

    void Start()
    {
        ////////////////////////////////////////////////////////////////////////
        //EXPLANATION OF WHERE EVERYTHING COMES FROM AND HOW EVERYTHING WORKS //
        ////////////////////////////////////////////////////////////////////////
        
        //Distance = Time x Speed (for uniform motion / no acceleration)
        //Assuming that the bullet and the player will collide, the distance the projectile travels can be found in terms of time (t), which can be used to find the player
        //position at the sime time.

        //Consider 2 points (x1, y1) and (x2, y2)
        //The distance (D) between them can be found using the equation:
        //D^2 = (x2-x1)^2 + (y2-y1)^2

        //We also know that D = t x s, which can also be written as:
        //D^2 = t^2 x s ^2

        //We can equate these to get:
        //s^2 x t^2 = (X-Tx)^2 + (Y-Ty)^2
        //(renamed the points to (X,Y) for collision point and (Tx,Ty) for shoot position to make it easier to read)

        //If the velocity of the player is (Vx, Vy) and the current position of the player is (Px, Py), you can rewrite X and Y as:
        //X = t * Vx + Px
        //Y = t * Vy + Ay

        //Substituting these into the previous equation gives us a new quadratic equation:
        //s^2 x t^2 = ((t x Vx + Px)-Tx)ˆ2 + ((t x Vy + Py)-Ty)ˆ2

        //By expanding and combining similar terms, you get the quadratic in the form ax^2 + bx + c = 0 (where x = t):
        //(Vxˆ2 +Vyˆ2 - sˆ2) * tˆ2 + 2* (Vx*(Px - Tx) + Vy*(Py - Ty)) *t + (Py - Ty)ˆ2 + (Px - Tx)ˆ2 = 0;
        
        //By calculating the discriminant (b^2 - 4ac) you can find out the number of collisions
        //if it is < 0, there are no collisions
        //if it is = 0, there is one collision
        //if it is > 0, there are 2 collisions

        //if there is at least 1 collision, we can calculate t using the quadratic formula:
        //t = (-b ± sqrrt(b^2 - 4ac)) / 2a

        //taking the LARGEST value of t, X and Y from earlier can be calculated using the formula mentioned earlier:
        //X = t * Vx + Px
        //Y = t * Vy + Ay

        //These X and Y values are the X and Y co-ordinates of the collision point
        //By subtracting the current position from the collision position, you can calculate the direction to the collision point
        //You can then rotate towards the collision point then move relative up by the already established speed value to collide with the player



        rb = GetComponent<Rigidbody2D>(); //Get the rigidbody (for setting velocity)
        targets = GameObject.FindGameObjectsWithTag("Player"); //Find everything tagged with player (should only be one)

        if (targets.Length <= 0)
        {
            //No player has been found
            Destroy(gameObject);
            return;
        }

        playerVelocity = targets[0].GetComponent<Rigidbody2D>().velocity; //Sets the player velocity variable to that of the first object found with tag player
        playerStartPos = targets[0].transform.position; //Does the same for start position
        shooterPos = transform.position; //Sets shooter pos to current position as this object has just been instantiated at said position

        float a = (playerVelocity.x * playerVelocity.x) + (playerVelocity.y * playerVelocity.y) - (projectileSpeed * projectileSpeed); //Gets a b and c
        float b = 2 * (playerVelocity.x * (playerStartPos.x - shooterPos.x) + playerVelocity.y * (playerStartPos.y - shooterPos.y));
        float c = ((playerStartPos.x - shooterPos.x) * (playerStartPos.x - shooterPos.x)) + ((playerStartPos.y - shooterPos.y) * (playerStartPos.y - shooterPos.y));

        float discriminant = (b * b) - (4*a*c); //Calculates the discriminant

        if (discriminant < 0) Destroy(gameObject); //There are no collisions
        else
        {
            //There are collisions
            float t1 = (-1 * b + Mathf.Sqrt(discriminant)) / (2 * a);
            float t2 = (-1 * b - Mathf.Sqrt(discriminant)) / (2 * a);

            //Get the bigger time to hit
            timeToHit = Mathf.Max(t1, t2);

            //Finds the x and y co-ordinates
            float x = (playerVelocity.x * timeToHit) + playerStartPos.x;
            float y = (playerVelocity.y * timeToHit) + playerStartPos.y;

            //Puts the x and y co-ordinates found into a vector2
            collisionPoint = new Vector2(x, y);

            Vector3 direction = new Vector3(collisionPoint.x, collisionPoint.y, transform.position.z) - transform.position;
            Quaternion toRotation = Quaternion.FromToRotation(transform.up, direction);
            transform.rotation = toRotation;

            rb.velocity = projectileSpeed * transform.up;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
