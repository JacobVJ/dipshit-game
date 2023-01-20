using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnscript : MonoBehaviour
{
    public GameObject enemy;
    GameObject newEnemy;
    List<GameObject> zombie = new List<GameObject>();
    // Start is called before the first frame update
    IEnumerator Start()
    {
        
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(3);
            newEnemy = Instantiate(enemy,transform.position+new Vector3(Random.insideUnitCircle.x*20,0, Random.insideUnitCircle.y*20), Quaternion.identity);
            zombie.Add(newEnemy);
        } 

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 10; i++)
        {

            zombie[i].transform.position = Vector3.MoveTowards(zombie[i].transform.position, transform.GetChild(0).position+new Vector3(Random.insideUnitCircle.x * 3, 0, Random.insideUnitCircle.y * 10), Time.deltaTime * 3);
        }
    }
}
