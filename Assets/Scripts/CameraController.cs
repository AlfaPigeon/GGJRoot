using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 TargetAng;
    void Start()
    {
        TargetAng =  target.position-transform.position ;
    }


    void Update()
    {
        Vector3 targ_pos = target.position - TargetAng;
        if (Vector3.Distance(targ_pos, transform.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, targ_pos, 5f * Time.deltaTime);
        }
    }
}
