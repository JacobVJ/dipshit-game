using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class input : MonoBehaviour
{
    private Rigidbody rb;
    Vector3 movemenVector;
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnMove(InputValue movementvalue)
    {
        movemenVector = new Vector3(movementvalue.Get<Vector2>().x, 0, movementvalue.Get<Vector2>().y);
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
}
