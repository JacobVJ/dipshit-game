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
    void Start()
    {
        Target = LayerMask.GetMask("Zombi");
        rb = GetComponent<Rigidbody>();
    }
    void OnMove(InputValue movementvalue)
    {
        movemenVector = new Vector3(movementvalue.Get<Vector2>().x, 0, movementvalue.Get<Vector2>().y);
    }
    void OnFire(InputValue fire)
    {
        ShootingRayCast();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + movemenVector*Time.deltaTime*speed;
        if(movemenVector != Vector3.zero)
        {
            transform.forward = movemenVector;
        }
    }


    int[] VåbenSkade = new int[] {72, 32, 156, 400 };
    string[] VåbenNavn = new string[] {"pistol","UZI", "Shotgun", "Sniper"};
   


    void ShootingRayCast()
    {
        Vector3 PlayerPosition = transform.position;
        Vector3 PlayerForward = transform.forward;
        Ray interactRay = new Ray(PlayerPosition, PlayerForward);
        RaycastHit interactHit;
        float RayLength=10.0f;
        Vector3 EndPoint = PlayerForward * RayLength;
        bool HitFound = Physics.Raycast(interactRay, out interactHit, RayLength, Target);
        if (HitFound)
        {
            GameObject enemy = interactHit.transform.gameObject;
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<ZombiScipt>().TakeDamage(72);
            }
        }

    }

    //                spawnscript.DeleteHunter(enemy);

}
