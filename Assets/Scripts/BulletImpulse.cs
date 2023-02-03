using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpulse : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    [SerializeField] private float force = 30;
    private Camera mainCamera;
    [SerializeField] private LayerMask groundMask;
    private void Awake()
    {
        rb.freezeRotation= true;
        rb.useGravity = false;
        rb = GetComponent<Rigidbody>();
        Aim();
        rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
    }

    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            // Calculate the direction
            var direction = position - transform.position;

            // You might want to delete this line.
            // Ignore the height difference.
            direction.y = 0;

            // Make the transform look in the direction.
            transform.forward = direction;
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        }
        else
        {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
    }
}
