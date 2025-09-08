using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContoller : MonoBehaviour
{
    Rigidbody rigby;
    Vector2 movement;
    public float moveInputSpeed = 5f;

    void Start()
    {
        
        rigby = GetComponent<Rigidbody>();    
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        
    }

    private void HandleMovement()
    {
        Vector3 currentPosition = rigby.position;
        Vector3 moveDirection = new Vector3(movement.x, 0f, 0f);
        Vector3 newPosition = currentPosition + moveDirection * moveInputSpeed * Time.deltaTime;
        //UnityDocs: Rigidbody.MovePosition
        rigby.MovePosition(newPosition);
    }

    

}
