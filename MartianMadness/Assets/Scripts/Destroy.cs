using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float positiveZLimit = 8.0f;
    private float negativeZLimit = -22.0f;
    private float xLimit = 12.0f;
    private float yLimit = 0.46f;
    public int timeToLive = 5;

    private GameManager gameManager;
    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > positiveZLimit || transform.position.z < negativeZLimit)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                gameManager.updateScore(-enemy.killReward);
            }
            Destroy(gameObject);
        }
        else if (transform.position.x < (-xLimit) || transform.position.x > xLimit || transform.position.y < yLimit)
        {
            Destroy(gameObject);
        }

        if(gameObject.CompareTag("Explosion"))
        {
            StartCoroutine(SuicideParticle());
        }

    }

    IEnumerator SuicideParticle()
    {

        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    }

}
