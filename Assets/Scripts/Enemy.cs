using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerController player;

    public float moveSpeed = 5f;


    public GameObject DeathParitcle;

    private CharacterController characterController;

    void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        UpdateMovement();
    }
    
    private void UpdateMovement()
    {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        characterController.SimpleMove(transform.forward);
    }
    public void Die()
    {
        Destroy (Instantiate(DeathParitcle,transform.position,transform.rotation),3f);
        Destroy(gameObject);
    }


}
