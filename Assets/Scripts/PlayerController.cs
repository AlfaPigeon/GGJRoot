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

       
        if(characterController.velocity.z > 0) { 
        animator.SetFloat("Velocity", characterController.velocity.magnitude);
        }
        else
        {
            animator.SetFloat("Velocity", -characterController.velocity.magnitude);
        }

        animator.SetFloat("Left", -characterController.velocity.x);
    }

    private void OnMovement(InputValue value)
    {
        move = value.Get<Vector2>();
    }
}
