using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiScipt : MonoBehaviour
{
    int health = 1000;
    public bool hunt=false;
    public void TakeDamage(int Skade)
    {
        health = health - Skade;
        if(health <= 0)
        {
            
        }
    }

    void Update()
    {
        if (hunt == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, Time.deltaTime * 3);
        }
    }
}


