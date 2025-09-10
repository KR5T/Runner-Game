using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContoller : MonoBehaviour
{
    Rigidbody rigby;
    Vector2 movement;
    public float moveInputSpeed = 5f;
    public float xClamp = 4.21f;
    public float zClamp = 3f;

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
        Vector3 moveDirection = new Vector3(movement.x, 0f, movement.y);
        Vector3 newPosition = currentPosition + moveDirection * moveInputSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z, -zClamp, zClamp);
        //UnityDocs: Rigidbody.MovePosition
        rigby.MovePosition(newPosition);
        
    }
}
