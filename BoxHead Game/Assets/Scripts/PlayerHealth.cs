using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 100;
    int pushingForce = 150;
    // n�r player collider med et andet gameobject
    private void OnCollisionEnter(Collision other)
    {
        //k�rer koden hvis gameobject er tagget med Enemy
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
                // N�r playeren d�r skiftes scenen til menu scenen, i dette tilf�lde "temp" scenen
                // n�r ny scenen skal addes, g� ind i scene, create new scene, i inspector klik p� files, build settings, add open scenens, drag new scene til build

            }
        }   
    }
}
