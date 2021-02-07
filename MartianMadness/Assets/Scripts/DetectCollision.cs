using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public ParticleSystem enemyExplosion;
    public ParticleSystem playerExplosion;
    private GameManager gameManager;
    private Enemy enemy;

    public static bool hasLaser = false;
    public static bool hasAutoGun = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemy = GetComponent<Enemy>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {


        if (gameObject.CompareTag("LaserAmmo") && other.gameObject.CompareTag("Player"))
        {
            hasLaser = true;
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("AutoGunAmmo") && other.gameObject.CompareTag("Player"))
        {
            hasAutoGun = true;
            Destroy(gameObject);
        }
        else if (!gameObject.CompareTag("LaserAmmo") && !gameObject.CompareTag("AutoGunAmmo"))
        {

            Destroy(gameObject);

            Destroy(other.gameObject);

            if (other.gameObject.CompareTag("Player"))
            {
                Instantiate(playerExplosion, gameObject.transform.position, playerExplosion.transform.rotation);
                gameManager.isGameOver = true;
            }
            else
            {
                Instantiate(enemyExplosion, gameObject.transform.position, enemyExplosion.transform.rotation);
                gameManager.updateScore(enemy.killReward);
            }


        }      

    }


}
