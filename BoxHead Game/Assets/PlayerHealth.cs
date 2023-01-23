using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int playerHealth = 100;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerHealth = playerHealth - 10;
        }
        if (playerHealth == 0)
        {
            Destroy(gameObject);
        }
    }

}
