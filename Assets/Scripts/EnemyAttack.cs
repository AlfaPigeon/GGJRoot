using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator m_Animator;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private string target_tag = "";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Root"))
        {
            target_tag = other.tag;
            m_Animator.SetTrigger("Attack");

        }
    }
    void AttackEVent()
    {
        
    }
}
   
