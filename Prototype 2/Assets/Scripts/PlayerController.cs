using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    public float speed = 10.0f;
    public float xRange = 10.0f;
    public float upRangeZ = 15.0f;
    public float downRangeZ = 0;


    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   //left boundary
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); // x,y,z, 
        }
        //right boundary
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z); // x,y,z, 
        }
        //up boundary
        if (transform.position.z > upRangeZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, upRangeZ);

        }
        //down boundary
        if (transform.position.z < downRangeZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, downRangeZ);

        }


        //Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
