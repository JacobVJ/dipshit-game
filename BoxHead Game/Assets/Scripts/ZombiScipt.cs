using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiScipt : MonoBehaviour
{
    int health = 500;
    public bool hunt=false;
    public GameObject PickUpBox;

    public void TakeDamage(int Skade)
    {
        health = health - Skade;
        if(health <= 0)
        {
            if (Random.Range(1, 2)==1)
            {
                PickUpBox = Instantiate(PickUpBox, transform.position,Quaternion.identity);
            }
            Destroy(gameObject);    
        }
    }

    void Update()
    {
        if (hunt == true)
        {   transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, Time.deltaTime * 3);    }
    }
}


