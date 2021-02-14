using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    private float lifeTimer;
    public float lifeDuration = 2;

    void OnEnable() { lifeTimer = lifeDuration; }
    void Update()
    {
        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0.0f)
        {
            gameObject.SetActive(false);
        }
    }
}
