using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform target;
    private Vector3 direction;
    public float speed = 5.0f;
    private float personalSpace = 0.1f;


    private void OnEnable()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 distance = target.position - transform.position;
        direction = distance.normalized;
        
        if(distance.magnitude > personalSpace)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }

    }
}
