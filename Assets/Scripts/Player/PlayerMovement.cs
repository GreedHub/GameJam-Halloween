using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 2f;
    [SerializeField] private float runSpeed = 4f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    private CharacterController controller;
    private Vector3 velocity;
    private float groundDistance = .4f;
    private float gravity = -9.81f;

    void Start(){
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update(){

        if(IsGrounded() && velocity.y < 0) velocity.y = -.05f;
                
        Vector3 rawDirection = GetInput();

        Vector3 move = transform.right * rawDirection.x + transform.forward * rawDirection.z;
        
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime * Time.deltaTime;

        controller.Move(velocity);
    }

    Vector3 GetInput(){

        Vector3 _input = Vector3.zero;
        _input.x = Input.GetAxis("Horizontal");
        _input.z = Input.GetAxis("Vertical");
       
        return _input;
    }

    bool IsGrounded(){
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}
