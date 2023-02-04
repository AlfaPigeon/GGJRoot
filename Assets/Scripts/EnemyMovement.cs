using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector3 movement;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

     
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        transform.LookAt(new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z));
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition((Vector3)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
