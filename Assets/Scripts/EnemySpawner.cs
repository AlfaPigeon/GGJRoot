using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class WaveContent
    {
        [SerializeField][NonReorderable] GameObject[] enemySpawner;

        public GameObject[] GetEnemySpawnList()
        {
            return enemySpawner;
        }
    }

    [SerializeField][NonReorderable] WaveContent[] waves;
    int currentWave = 0;
    float spawnRange = 10;
    public List<GameObject> currentEnemies;
    void Start()
    {
        SpawnWave();
    }

     
    void Update()
    {
        if (currentEnemies.Count==0)
        {
             
            currentWave++;
            SpawnWave();
        }
    }
    void SpawnWave()
    {
        for (int i = 0; i < waves[currentWave].GetEnemySpawnList().Length; i++) 
        {


            GameObject newspawn = Instantiate(waves[currentWave].GetEnemySpawnList()[i],FindSpawnLoc(),Quaternion.identity);
            currentEnemies.Add(newspawn);

            EnemyMovement monster = newspawn.GetComponent<EnemyMovement>();
            monster.SetSpawner(this);
        }
    }
    Vector3 FindSpawnLoc()
    {
        Vector3 SpawnPos;
     

    float xLoc = Random.Range(-spawnRange, spawnRange) + transform.position.x;
    float zLoc = Random.Range(-spawnRange, spawnRange) + transform.position.z;
    float yLoc = transform.position.y;

    SpawnPos = new Vector3(xLoc, yLoc, zLoc);
    if (Physics.Raycast(SpawnPos,Vector3.down,5))
    {
        return SpawnPos;
    }
    else
    {
        return FindSpawnLoc();
    }

}
}
