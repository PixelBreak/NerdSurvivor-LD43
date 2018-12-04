using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    [SerializeField] Transform[] spawnPoints;
    public static int enemyCount = 5;
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] float spawnDelay = 1;
    [SerializeField] int maxEnemy = 30;
    private float nextSpawn;

    private void Update()
    {
        if(Time.time > nextSpawn && enemyCount < maxEnemy)
        {

            nextSpawn = Time.time + spawnDelay;

            int r = Random.Range(0, 10);
            if(r == 0)
            {
                GameObject s = Instantiate(enemyPrefabs[1], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            }
            else
            {
                GameObject s = Instantiate(enemyPrefabs[0], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            }
            enemyCount++;
        }
    }


}
