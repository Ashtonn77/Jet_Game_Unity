using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public float speed = 18.0f;
    private float horizontalInput;
    private float verticalInput;
    private float xLimit = 12.0f;
    private float negativeZLimit = -19.0f;
    private float positiveZLimit = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

   void FixedUpdate()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
       

        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -xLimit, xLimit);
        viewPos.z = Mathf.Clamp(viewPos.z, negativeZLimit, positiveZLimit);
        transform.position = viewPos;

    }


   

}
