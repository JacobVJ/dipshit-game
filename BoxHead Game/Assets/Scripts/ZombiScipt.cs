using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiScipt : MonoBehaviour
{
    public int health = 500;
    public bool hunt=false;
    public GameObject PickUpBox;
    public Renderer Object;
    public Material Material1;
    public Material Material2;
    WaitForSeconds wait = new WaitForSeconds(1);


    public void TakeDamage(int Skade)
    {
        health = health - Skade;
        if(health <= 0)
        {
            if (Random.Range(1, 4)==2)
            {
                PickUpBox = Instantiate(PickUpBox, transform.position,Quaternion.identity);
            }
            GameObject.FindGameObjectWithTag("Round").GetComponent<spawnscript>().NewRound();
            Destroy(gameObject);    
        }
        else
        {
            Object.material = Material1;
            IEnumerator coroutine = waitx(0.2f);
            StartCoroutine(coroutine);
        }
    }
    IEnumerator waitx(float x)
    {   yield return new WaitForSeconds(x);
        Object.material = Material2;
    }

    void Update()
    {
        if (hunt == true)
        {   transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, Time.deltaTime * 3);    }
    }
}


