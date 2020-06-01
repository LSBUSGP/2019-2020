using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{

    public Transform firePoint;

    public GameObject snowball;

    private bool offCooldownA = true;


    private int rechargeZ = 0;

    public float distance;

    // Update is called once per frame
    void Update()
    {
        //shooting normal arrows(basic attack)
        if (Input.GetButtonDown("Fire1"))
        {
            if (offCooldownA == true)
            {
                Instantiate(snowball, firePoint.position, firePoint.rotation);
                offCooldownA = false;
                //animator.SetBool("IsShooting", true);
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            //animator.SetBool("IsShooting", false);
        }


        //cooldown on Z ability(basic attack)

        if (offCooldownA == false)
        {
            if (rechargeZ > 30)
            {
                offCooldownA = true;
                rechargeZ = 0;
            }
            else
            {
                rechargeZ++;
            }
            
        }

    }
}
