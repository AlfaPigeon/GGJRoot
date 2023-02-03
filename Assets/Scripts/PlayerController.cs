using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController characterController;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    private void Update()
    {
        UpdateMovement();
    }


    public void UpdateMovement()
    {
        
    }
}
