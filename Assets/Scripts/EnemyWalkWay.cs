using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkWay : MonoBehaviour
{
     public GameObject _usRoots;
    RaycastHit _enemyDrawLine;
    Rigidbody _rig;

    private void Start()
    {
      //  _rig = GetComponent<Rigidbody>();
        
        
    }
    void Drawline()
    {

        Vector3 _enemyWay = _usRoots.transform.position - transform.position;
        Physics.Raycast(transform.position, _enemyWay,1000);
        Debug.DrawLine(transform.position, _enemyWay,Color.magenta);
    }

    private void Update()
    {
        transform.LookAt(_usRoots.transform.position);
        transform.position = Vector3.Lerp(transform.position, _usRoots.transform.position, (Time.deltaTime * 1f)/Vector3.Distance(transform.position, _usRoots.transform.position)); ;
    }

    void FixedUpdate()
    {
        Drawline();
        

    }
}
