using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.0f;
    [SerializeField]
    private float gravityScale = 1.0f;
    private float jump = 150f;
    private float gravity = -9.8f;
    
    private CharacterController characterController;
    private RaycastController raycastController;
    private InventoryManager InventoryManager;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        raycastController = GetComponentInChildren<RaycastController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
       float xMove = Input.GetAxis("Horizontal");
       float zMove = Input.GetAxis("Vertical");
        
        Vector3 moveDirection = (transform.right * xMove) + (transform.forward * zMove);
        moveDirection.y += gravity * Time.deltaTime * gravityScale;
        moveDirection *= moveSpeed * Time.deltaTime;

       if (Input.GetButtonDown("Jump") && raycastController.IsGrounded()) 
        {
            moveDirection.y += jump * Time.deltaTime;
            Debug.Log("Jumped");
        }
        //Debug.Log(moveDirection);
        characterController.Move(moveDirection);
    }
}
