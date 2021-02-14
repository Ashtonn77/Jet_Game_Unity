using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    private static PoolingManager instance;
    public static PoolingManager Instance { get { return instance; } }

    [SerializeField] int minObjectsInScene = 5;
    public GameObject bulletPrefab;
    public GameObject enemyPrefab;
    public GameObject enemyExplosionPrefab;

    public List<GameObject> Bullets { get; private set; }
    public List<GameObject> Enemies { get; private set; }
    public List<GameObject> EnemyExplosions { get; private set; }

    void Awake()
    {
        instance = this;
        Bullets = new List<GameObject>();
        Enemies = new List<GameObject>();
        EnemyExplosions = new List<GameObject>();

        for (int i = 0; i < minObjectsInScene; i++)
        {
         
            InstantiatePoolingPrefab(bulletPrefab, Bullets);
            
            InstantiatePoolingPrefab(enemyPrefab, Enemies);

            InstantiatePoolingPrefab(enemyExplosionPrefab, EnemyExplosions);

        }
    }

    public GameObject InstantiatePoolingPrefab(GameObject originalPrefab, List<GameObject> objectsList, bool active = false)
    {
        GameObject prefabInstance = Instantiate(originalPrefab);
        prefabInstance.transform.SetParent(transform);
        prefabInstance.SetActive(active);

        objectsList.Add(prefabInstance);

        return prefabInstance;
    }


    public GameObject GetObject(GameObject obj, List<GameObject> bucket)
    {
        foreach (var item in bucket)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                return item;
            }
        }

        return InstantiatePoolingPrefab(obj, bucket, true);
    }


}
