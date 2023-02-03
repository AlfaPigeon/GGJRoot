using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject prefabs;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Shot()
    {
        Instantiate(prefabs,transform.position,Quaternion.identity);
    }
    
}
