using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class input : MonoBehaviour
{
    private Rigidbody rb;
    Vector3 movemenVector;
    public float speed = 3;
    public spawnscript spawnscript;
    void Start()
    {
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
    void ShootingRayCast()
    {
        Vector3 PlayerPosition = transform.position;
        Vector3 PlayerForward = transform.forward;
        Ray interactRay = new Ray(PlayerPosition, PlayerForward);
        RaycastHit interactHit;
        float RayLength=5.0f;
        Vector3 EndPoint = PlayerForward * RayLength;
        bool HitFound = Physics.Raycast(interactRay, out interactHit, RayLength);
        if (HitFound)
        {
            GameObject enemy = interactHit.transform.gameObject;
            if (enemy.CompareTag("Enemy"))
            {
                spawnscript.DeleteHunter(enemy);
                Destroy(enemy); 
            }
        }


    }

}
