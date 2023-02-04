using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float speed = 1f;
    private CharacterController characterController;
    private Vector2 move;
    private Animator animator;
   
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        move = Vector2.zero;
       
    }


    private void Update()
    {
        UpdateMovement();
    }


    public void UpdateMovement()
    {
        if(move != Vector2.zero)
        {
            characterController.SimpleMove(new Vector3(move.x,transform.position.y,move.y).normalized*speed);
        }
        
        float forward_value = Vector3.Dot(characterController.velocity.normalized, transform.forward.normalized);
        float left_value  = Vector3.Dot(characterController.velocity.normalized, -transform.right.normalized);
        if (forward_value > 0) 
        { 
            animator.SetFloat("Velocity", 1f);
        }
        else if(forward_value < 0)
        {
            animator.SetFloat("Velocity", -1f);
        }
        else
        {
            animator.SetFloat("Velocity", 0f);
        }

        animator.SetFloat("Left", left_value);
    }

    private void OnMovement(InputValue value)
    {
        move = value.Get<Vector2>();
    }
}
