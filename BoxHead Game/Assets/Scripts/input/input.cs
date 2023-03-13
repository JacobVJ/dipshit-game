using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class input : MonoBehaviour
{
    private Rigidbody rb;
    Vector3 movemenVector;
    public float speed = 5;
    public spawnscript spawnscript;
    LayerMask Target;
    float ClockTime=0;
    //PickUpBox
    public float[] FireRate = new float[] { 0.5f, 13, 0.2f, 0.3f };
    public int[] VåbenSkade = new int[] { 72, 32, 156, 400 };
    public int[] Ammo = new int[] { 9999, 0, 0, 0 };
    public int[] AmmoDefault = new int[] { 9999, 300, 20, 15 };
    public string[] VåbenNavn = new string[] { "pistol", "UZI", "Shotgun", "Sniper" };

    public int PickUpNum = 0;
    void Start()
    {
        Target = LayerMask.GetMask("Zombi");
        rb = GetComponent<Rigidbody>();
        Debug.Log(FireRate[PickUpNum]);
    }
    void OnMove(InputValue movementvalue)
    {   movemenVector = new Vector3(movementvalue.Get<Vector2>().x, 0, movementvalue.Get<Vector2>().y);     }
                                                                                                                    /*
                                                                                                                    void OnFire(InputValue fire)
                                                                                                                    {
                                                                                                                        Debug.Log("fire");
                                                                                                                        ShootingRayCast();
                                                                                                                    }
                                                                                                                    */
    void Update()   
    {
        transform.position = transform.position + movemenVector*Time.deltaTime*speed;
        // opdater playerens position i vectorens retning
        if(movemenVector != Vector3.zero)
        {   transform.forward = movemenVector;  }
        ClockTime = ClockTime + Time.deltaTime;
                                                                                //Debug.Log(ClockTime);
                                                                                //Debug.Log(Input.GetMouseButton(0));
        if (Input.GetMouseButton(0))    
            //kør når museknap er nede
        {
            if (ClockTime > FireRate[PickUpNum])
            {
                ShootingRayCast();      
                // kør ShootingRayCast function
                ClockTime = 0;          
                // reset clockTime til 0
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        { transform.GetChild(PickUpNum).gameObject.SetActive(false); PickUpNum = 0; transform.GetChild(PickUpNum).gameObject.SetActive(true); }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        { transform.GetChild(PickUpNum).gameObject.SetActive(false); PickUpNum = 1; transform.GetChild(PickUpNum).gameObject.SetActive(true); }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        { transform.GetChild(PickUpNum).gameObject.SetActive(false); PickUpNum = 2; transform.GetChild(PickUpNum).gameObject.SetActive(true); }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        { transform.GetChild(PickUpNum).gameObject.SetActive(false); PickUpNum = 3; transform.GetChild(PickUpNum).gameObject.SetActive(true); }
        //hvis man trykker på 1,2,3,4 vil våbnet blive deactiveret, så ændres PickUpNum til responderende nummer, og så activeres våbnet til det nye PickUpNum værdi
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {   speed = 15;    }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        { speed = 8; }
    }
    void ShootingRayCast()  // functionen tjekker RayCastHit
    {
        if (Ammo[PickUpNum]>0)
        {
            Vector3 PlayerPosition = transform.position;
            Vector3 PlayerForward = transform.forward;
            Ray interactRay = new Ray(PlayerPosition, PlayerForward);
            RaycastHit interactHit;
            float RayLength = 20.0f;
            Vector3 EndPoint = PlayerForward * RayLength;
            bool HitFound = Physics.Raycast(interactRay, out interactHit, RayLength, Target);
            if (HitFound)
            {
                GameObject enemy = interactHit.transform.gameObject;
                if (enemy.CompareTag("Enemy"))
                { enemy.GetComponent<ZombiScipt>().TakeDamage(VåbenSkade[PickUpNum]); }
            }
            Ammo[PickUpNum] = Ammo[PickUpNum] - 1;
        }
        else { Debug.Log("no ammo"); }
    }
}
