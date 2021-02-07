using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject autoGunPrefab;
    public GameObject laserPrefab;


    public GameObject[] ammoPrefab;

    public GameObject player;
    public GameObject[] enemiesPrefab;
    private float xPos = 12.0f;
    private float zPos = 7.0f;

    private int enemyCount = 0;
    public int numOfEnemies = 1;


    private GameManager gameManager;
    //public static DetectCollision detectCollisionSript;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();        
        InvokeRepeating("SpawnAmmo", 5.0f, Random.Range(2, 6));

    }
    // Update is called once per frame
    void Update()
    {
        //detectCollisionSript = FindObjectOfType<DetectCollision>();
        

        if (DetectCollision.hasLaser) { StartCoroutine(KamikaziAmmoClip(2, 1)); }
        if (DetectCollision.hasAutoGun) { StartCoroutine(KamikaziAmmoClip(2, 2)); }



        if (DetectCollision.hasLaser)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Vector3 spawnPosLaser = player.transform.position + new Vector3(0, 0, 2.0f);
                    Instantiate(laserPrefab, spawnPosLaser, laserPrefab.transform.rotation);
                }
            }
            else if (DetectCollision.hasAutoGun)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    Vector3 spawnPosAutoGun = player.transform.position + new Vector3(0.8f, 0, 0);
                    Instantiate(autoGunPrefab, spawnPosAutoGun, autoGunPrefab.transform.rotation);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Instantiate(bulletPrefab, player.transform.position, bulletPrefab.transform.rotation);
                }
            }

        


        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount < 1)
        {
            spawnEnemies(numOfEnemies++);
        }

    }

    void spawnEnemies(int numOfEnemies)
    {
        if (!gameManager.isGameOver)
        {
            for (int i = 0; i < numOfEnemies; i++)
            {
                int randomEnemy = Random.Range(0, enemiesPrefab.Length);
                Vector3 spawnPos = new Vector3(Random.Range(-xPos, xPos), 0.46f, zPos);

                var hitColliders = Physics.OverlapBox(spawnPos, spawnPos / 2);

                if (hitColliders.Length > 0) continue;

                Instantiate(enemiesPrefab[randomEnemy], spawnPos, enemiesPrefab[randomEnemy].transform.rotation);
            }
        }
    }

    IEnumerator KamikaziAmmoClip(int timeToLive, int ammoType)
    {
        yield return new WaitForSeconds(timeToLive);
        if (ammoType == 1)
        {
            DetectCollision.hasLaser = false;
        }
        else if (ammoType == 2)
        {
            DetectCollision.hasAutoGun = false;
        }
    }
        
    void SpawnAmmo()
    {

        if (!gameManager.isGameOver)
        {

            int randomAmmo = Random.Range(0, ammoPrefab.Length);
            Vector3 spawnAmmoPos = new Vector3(Random.Range(-xPos, xPos), 0.46f, zPos - 3.0f);
            Instantiate(ammoPrefab[randomAmmo], spawnAmmoPos, ammoPrefab[randomAmmo].transform.rotation);

        }
    
    }

}

