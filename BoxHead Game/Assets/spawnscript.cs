using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class spawnscript : MonoBehaviour
{
    public GameObject enemy;
    GameObject newEnemy;
    List<GameObject> zombie = new List<GameObject>();
    List<GameObject> hunter = new List<GameObject>();
    int PlayerHealth = 100;
    // Start is called before the first frame update
    IEnumerator Start()
    {     
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1);
            newEnemy = Instantiate(enemy, transform.position + new Vector3(Random.insideUnitCircle.x * 20, 0.3f, Random.insideUnitCircle.y * 20), Quaternion.identity);
            zombie.Add(newEnemy);
        } 
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < zombie.Count; i++)
        {
            print(zombie.Contains(zombie[i]));
            if (zombie.Contains(zombie[i]))
            {
                zombie[i].transform.position = Vector3.MoveTowards(zombie[i].transform.position, transform.GetChild(0).position + new Vector3(Random.insideUnitCircle.x * 2, 0.3f, Random.insideUnitCircle.y * 20), Time.deltaTime * 3);
                
            }
        }
    }

    public void ChangeZombieToHunter(GameObject zombieObject)
    {
        zombieObject.GetComponent<ZombiScipt>().hunt=true;
        zombie.Remove(zombieObject);
    }
    public void DeleteHunter(GameObject Hunterobject)
    {
        hunter.Remove(Hunterobject);
    }


    void boxspawn()
    {
        //if (hunter die)
        //{
        // instatiate(box, hunter.transform.position, quaternion.identity);
        // make "box" a pickup
        // if Player.transform.position == transform.box.position + new Vector3(x,y,z)
        // {
        //  PlayerHealth=PlayerHealth+10;
        // }
        // if (hunter[i].transform.position == GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(Random.insideUnitCircle.x * 2, 0, Random.insideUnitCircle.y * 2))
        // {
        //  PlayerHealth = PlayerHealth - 10;
        //  yield return new WaitForSeconds(1);
        // }
        //}
    }
}
