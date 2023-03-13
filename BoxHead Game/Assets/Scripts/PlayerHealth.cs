using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 100;
    int pushingForce = 150;
    // når player collider med et andet gameobject
    private void OnCollisionEnter(Collision other)
    {
        //kører koden hvis gameobject er tagget med Enemy
        if (other.gameObject.CompareTag("Enemy"))
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
            {
                SceneManager.LoadScene("temp");
                // Når playeren dør skiftes scenen til menu scenen, i dette tilfælde "temp" scenen
                // når ny scenen skal addes, gå ind i scene, create new scene, i inspector klik på files, build settings, add open scenens, drag new scene til build

            }
        }   
    }
}
