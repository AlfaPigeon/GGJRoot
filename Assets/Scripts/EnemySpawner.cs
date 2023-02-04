using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    public GameObject _enemy;
    public float safe_distance = 10f;
    public float max_distance = 50f;
    public float wave_enemy_count = 10f;

    void Start()
    {
        SpawnWave();
    }

     
    void Update()
    {

    }
    public void SpawnWave()
    {
        for(int i = 0; i< wave_enemy_count; i++)
        {
            Instantiate(_enemy, FindSpawnLoc(), Quaternion.identity);
        }
    }
    private  Vector3 FindSpawnLoc()
    {
        Vector2 random_circle =Random.insideUnitCircle;
        Vector3 direction = new Vector3(random_circle.x,transform.position.y,random_circle.y);
        return direction * Random.Range(safe_distance, max_distance);
    }
}
