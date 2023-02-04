using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    public static RootController Instance;

    public float Max_Health = 100f;
    public float Current_Health = 100f;

    public HealBar healBar;

    void Start()
    {
        Instance = this;
        healBar.SetMaxHealth(Max_Health);
    }


    public void GetHit(float value)
    {
        Current_Health -= value;
        if(Current_Health <= 0)
        {
           
            Die();
        }
        else
        {
            healBar.SetHealth(Current_Health);
        }
       
    }
    public void Die()
    {
        healBar.SetHealth(0);


    }

}
