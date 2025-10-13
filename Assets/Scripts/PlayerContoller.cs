using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContoller : MonoBehaviour
{
    Rigidbody rigby;
    public Vector2 movement;
    public float moveInputSpeed = 5f;
    public float xClamp = 4.21f;
    public float zClamp = 3f;
    [Header("Jetpack")]
    private bool isJetpacking = false;
    public float jetpackForce = 5f;
    public float gravityForce = 10f;
    public float verticalVelocity;
    private float groundY = 0f;
    public float yClamp = 10f;

    void Start()
    {

        rigby = GetComponent<Rigidbody>();
    }

    void Update()
    {
        IsJetpacking();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    void IsJetpacking()
    {
        isJetpacking = movement.y > 0.5f;
    }

    private void HandleMovement()
    {
        Vector3 currentPosition = rigby.position;
        Vector3 moveDirection = new Vector3(movement.x, 0f, 0f);
        Vector3 newPosition = currentPosition + moveDirection * moveInputSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        //newPosition.z = Mathf.Clamp(newPosition.z, -zClamp, zClamp);

        if (isJetpacking)
        {
            Debug.Log("jetpack ateşlendi");
            verticalVelocity += jetpackForce * Time.deltaTime;
        }
        else
        {
            Debug.Log("jetpack söndü");
            verticalVelocity = 0;
            verticalVelocity -= gravityForce * Time.deltaTime;
        }
        //verticalVelocity = Mathf.Clamp(verticalVelocity, -gravityForce, jetpackForce * 2f);
        
        newPosition.y += verticalVelocity * Time.deltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, groundY, yClamp);
        
        if (newPosition.y <= groundY)
        {
            newPosition.y = groundY;
            verticalVelocity = 0f;
        }
        
        //UnityDocs: Rigidbody.MovePosition
        rigby.MovePosition(newPosition);
    }
}
