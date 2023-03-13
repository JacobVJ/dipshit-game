using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class spawnscript : MonoBehaviour
{
    float ZombieCount = 10;
    public GameObject enemy;
    GameObject newEnemy;
    List<GameObject> zombie = new List<GameObject>();
    List<GameObject> hunter = new List<GameObject>();
    int RoundHealth = 0; 
    // Start is called before the first frame update
    IEnumerator Start()
    {     
        for (int i = 0; i < (int)ZombieCount; i++)
        {
            yield return new WaitForSeconds(1);
            newEnemy = Instantiate(enemy, transform.position + new Vector3(Random.insideUnitCircle.x * 20, 0.3f, Random.insideUnitCircle.y * 20), Quaternion.identity);
            zombie.Add(newEnemy);
            newEnemy.GetComponent<ZombiScipt>().health= newEnemy.GetComponent<ZombiScipt>().health+30*RoundHealth;
            RoundHealth++;
        } 
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < zombie.Count; i++)
        {
            if (zombie.Contains(zombie[i]))
            {   zombie[i].transform.position = Vector3.MoveTowards(zombie[i].transform.position, transform.GetChild(0).position + new Vector3(Random.insideUnitCircle.x * 2, 0.3f, Random.insideUnitCircle.y * 20), Time.deltaTime * 3);    }
        }
    }

    public void ChangeZombieToHunter(GameObject zombieObject)
    {
        zombieObject.GetComponent<ZombiScipt>().hunt=true;
        zombie.Remove(zombieObject);
    }
    public void DeleteHunter(GameObject Hunterobject)
    {   hunter.Remove(Hunterobject);    }

    public void NewRound()
    {
        GameObject[] deadZombies = GameObject.FindGameObjectsWithTag("Enemy");
        if(deadZombies.Length ==1)
        {
            Debug.Log("more zombies to kill");
            ZombieCount = ZombieCount * 1.2f;
            StartCoroutine("Start");
        }
    }
}
