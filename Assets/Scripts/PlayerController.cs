using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [Header("Attack")]
    public float shooting_cooldown = 0.3f;
    public float shooting_velocity= 5f;
    private bool can_shoot = true;
    public GameObject Fireball_prefab;
    public Transform ShootPoint;
    [Header("Movement")]
    public float speed = 1f;
    private CharacterController characterController;
    private Vector2 move;
    private Animator animator;
    private bool shoot = false;
    private void Start()
    {
        Instance = this;

        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        move = Vector2.zero;
       
    }


    private void Update()
    {
        UpdateMovement();
        UpdateShoot();
    }



    public void UpdateShoot()
    {

        if (shoot && can_shoot)
        {

            can_shoot = false;
            
            animator.SetTrigger("Attack");
        }
    }
    public void Attack()
    {
        GameObject fireball =  Instantiate(Fireball_prefab, ShootPoint.position, ShootPoint.rotation);
        Rigidbody fireball_rb = fireball.GetComponent<Rigidbody>();

        fireball_rb.velocity = ShootPoint.forward * shooting_velocity;


    }
    private IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(shooting_cooldown);
        can_shoot = true;
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

 

    public void AttackEvent()
    {
        Attack();
        StartCoroutine(ResetCooldown());
    }
    private void OnMovement(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    private void OnShoot(InputValue value)
    {
        shoot = value.isPressed;
    }
}
