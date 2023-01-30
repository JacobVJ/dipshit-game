using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int playerHealth = 100;
    int pushingForce = 300;
    // når player collider med et andet gameobject
    private void OnTriggerEnter(Collider other)
    {
        //kører koden hvis gameobject er tagget med Enemy
        if (other.CompareTag("Enemy"))
        {
            //the rigidbody of your object
            Rigidbody rb = GetComponent<Rigidbody>();
            //calculating the direction where we should push our object
            Vector3 direction = transform.position - other.transform.position;
            // skub player i vector3 retningen "direction" ganget med pushingForce
            rb.AddForce(direction * pushingForce);
            // PlayerHealth - 10
            playerHealth = playerHealth - 10;
            // hvis PlayerHealth <= 0 fjern player
            if (playerHealth <= 0)
            {   Destroy(gameObject);    }
        }       
    }   
}
