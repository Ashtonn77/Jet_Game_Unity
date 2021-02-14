using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseFollowPlayerBullets : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;
    List<GameObject> followBullets;

    void Awake()
    {
        followBullets = new List<GameObject>();       
    }
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {            
            GameObject obj = PoolingManager.Instance.GetObject(bulletPrefab, followBullets);
            obj.transform.position = transform.position; 

        }

    }
}
