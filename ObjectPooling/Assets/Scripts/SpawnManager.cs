using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    [SerializeField] int maxEnemiesPerSpawn = 10;

    private float xRange = 8;
    private float zRange = 14;
    
    void Update()
    {
 
        if(Input.GetKeyDown(KeyCode.C))
        {
           
            SpawnEnemyCluster(maxEnemiesPerSpawn);
        }
   
    }

    float[] GetRandomRangePosition()
    {
        float _x = Random.Range(-xRange, xRange);
        float _z = Random.Range(5, zRange);
    
        return new float[] { _x, _z };
    }

    void SpawnEnemy(float[] point)
    {
        GameObject enemyObject = PoolingManager.Instance.GetObject
            (
            PoolingManager.Instance.enemyPrefab, PoolingManager.Instance.Enemies
            );
        enemyObject.transform.position = new Vector3(point[0], 1, point[1]);
    }

    void SpawnEnemyCluster(int limit)
    {

        IDictionary<float[], bool> enemyMap = new Dictionary<float[], bool>();

        float[] point = GetRandomRangePosition();

        int enemiesSpawned = 0;
        while(enemiesSpawned < limit)
        {
            if (enemyMap.ContainsKey(point))
            {
                point = GetRandomRangePosition();
            }
            else
            {
                SpawnEnemy(point);
                enemyMap.Add(point, true);
                enemiesSpawned++;
            }

        }      

    }

}
