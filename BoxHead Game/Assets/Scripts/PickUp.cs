using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public input inputscript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inputscript =other.GetComponent<input>();
            int x = Random.Range(0, inputscript.V�benSkade.Length);
            inputscript.PickUpNum = x;      
            //Disse 3 linjer laver et random tal fra 0 til antal elementer i og inds�tter integeren ind i variablen PickUpNum i scriptet input
            for(int i = 0; i <= inputscript.V�benNavn.Length-1; i++)
            {
                other.transform.GetChild(i).gameObject.SetActive(false);
                Debug.Log("hi hi hi hi hi");
            }
            other.transform.GetChild(x).gameObject.SetActive(true);
            // activer v�ben til x
            inputscript.Ammo[x] = inputscript.AmmoDefault[x];         
            Debug.Log(inputscript.V�benNavn[x] + "; " + inputscript.FireRate[x] + "; " + inputscript.V�benSkade[x] + "; " + "Ammunition: "+ inputscript.AmmoDefault[x]);     
            // displayer Navn; Firerate; Skade i consollen
            Destroy(gameObject);        
            //�del�gger PickUpBox           
        }
    }
}
