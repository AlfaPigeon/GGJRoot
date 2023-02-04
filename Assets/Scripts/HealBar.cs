using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBar : MonoBehaviour
{
    [Range(0f, 100f)]
    public float Heal = 100f;
    void Start()
    {
        
    }

     
    void Update()
    {
        gameObject.transform.localScale = new Vector3(Heal / 100, 1, 1);
    }
}
