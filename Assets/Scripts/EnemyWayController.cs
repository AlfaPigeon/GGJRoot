using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayController : MonoBehaviour
{
    public GameObject _enemy;
    public Vector3 _randomPosition;
    public float safe_distance = 10;
    public float MAX_distance = 50;
    // Start is called before the first frame update
    void Start()
    {
        RandomEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RandomEnemy()
    {
        Vector3 vec = new Vector3(Random.Range(-_randomPosition.x, _randomPosition.x), 2, Random.Range(-_randomPosition.z,_randomPosition.z));
        Vector3 direction = (vec - transform.position).normalized;

        Instantiate(_enemy, direction*Random.Range(safe_distance,MAX_distance), Quaternion.identity);
    }
}
