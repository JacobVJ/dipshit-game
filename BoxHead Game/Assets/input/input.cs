using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class input : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnMove(InputValue movementvalue)
    {
        Vector2 movemenVector = movementvalue.Get<Vector2>();
        transform.position = transform.position + new Vector3(movemenVector.x,0,movemenVector.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
