using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);

           GameObject explosionObject = PoolingManager.Instance.GetObject
                                        (
                                        PoolingManager.Instance.enemyExplosionPrefab, PoolingManager.Instance.EnemyExplosions
                                        );
           explosionObject.transform.position = other.transform.position;

        }
    }



}
