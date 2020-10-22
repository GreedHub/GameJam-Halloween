using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    [SerializeField] private float speed = 5f;
    private Vector3 velocity;
    private float gravity = -9.81f;
    [SerializeField] Transform groundCheck;
    float groundDistance = .4f;
    [SerializeField] LayerMask groundMask;

    void Start(){
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update(){

        if(IsGrounded() && velocity.y < 0) velocity.y = -.2f;
                
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
