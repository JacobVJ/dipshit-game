using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnscript : MonoBehaviour
{
    public GameObject enemy;
    GameObject newEnemy;
    List<GameObject> zombie = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            newEnemy = Instantiate(enemy);
            zombie.Add(newEnemy);
        } 

    }

    // Update is called once per frame
    void Update()
    {

        newEnemy.transform.position = Vector3.MoveTowards(newEnemy.transform.position, transform.GetChild(0).position, Time.deltaTime*1);
    }
}
