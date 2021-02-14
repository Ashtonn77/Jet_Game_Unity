using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    private float xRange = 8;
    private float zRange = 14;

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {

            GameObject bulletObject = PoolingManager.Instance.GetObject(PoolingManager.Instance.bulletPrefab, PoolingManager.Instance.Bullets);
            bulletObject.transform.position = transform.position + transform.forward;
            bulletObject.transform.forward = transform.forward;
            
        }


        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);

        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -xRange, xRange);
        viewPos.z = Mathf.Clamp(viewPos.z, 0, zRange);

        transform.position = viewPos;

    }
}
