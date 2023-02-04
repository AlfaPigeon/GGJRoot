using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject explosion;
    private void Start()
    {
        Destroy(gameObject, 10f);
    }


 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            Explode();
            if(other.tag == "Enemy")
            {
                other.gameObject.GetComponent<Enemy>().Die();
            }
        }
    }
    private void Explode()
    {
        Destroy( Instantiate(explosion, transform.position, transform.rotation),3f);
        Destroy(gameObject);
    }
}
