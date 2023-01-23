using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterScriptTrigger : MonoBehaviour
{
    public spawnscript spawnscript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            spawnscript.ChangeZombieToHunter(other.gameObject);
        }
    }
}
