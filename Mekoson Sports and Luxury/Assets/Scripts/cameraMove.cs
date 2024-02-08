using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    Rigidbody rb;
    public Transform centerOfRotation; 
    public float rotationSpeed = 30f;
    public float orbitSpeed = 30f;
    public float moveSpeed = 5f;
    float rotationAmount;
    Transform childTransform;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (transform.childCount > 0)
        {
            childTransform = transform.GetChild(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardDirection = transform.forward;

        // Move the object forward based on its forward direction
        
        // if (Input.GetKeyDown("space")){
        //     rb.velocity = new Vector3(rb.velocity.x,5,rb.velocity.z);
        // }
        if (Input.GetKey(KeyCode.W)){
            //rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,5);
            transform.Translate(forwardDirection * moveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D)){
            //rb.velocity = new Vector3(5,0,rb.velocity.z);
            transform.Translate(transform.right * moveSpeed * Time.deltaTime, Space.World);
            //rotationAmount = rotationSpeed * Time.deltaTime;
            //transform.Rotate(Vector3.up, rotationAmount);
        }
        if (Input.GetKey(KeyCode.S)){
            //rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,-5);
            transform.Translate(forwardDirection * -moveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A)){
            //rb.velocity = new Vector3(-5,rb.velocity.y,rb.velocity.z);
            transform.Translate(-transform.right * moveSpeed * Time.deltaTime, Space.World);
            //rotationAmount = rotationSpeed * Time.deltaTime;
            //transform.Rotate(Vector3.up, -rotationAmount);
        }
        if (Input.GetKey("left")){
            // Calculate the desired position in a circle around the center of rotation
            //Vector3 offset = Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0) * (transform.position - centerOfRotation.position);
            //transform.position = centerOfRotation.position + offset;


            Quaternion orbitRotation = Quaternion.Euler(0f, -orbitSpeed * Time.deltaTime, 0f);
            Vector3 offset = transform.position - centerOfRotation.position;
            offset = orbitRotation * offset;
            transform.position = centerOfRotation.position + offset;

            // Keep x and z rotations constant
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.x = 0f;
            eulerAngles.z = 0f;
            transform.eulerAngles = eulerAngles;



            rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, -rotationAmount);
            // Rotate the object to look at the center of rotation
            //transform.LookAt(centerOfRotation);
        }
        if (Input.GetKey("right")){
        //     //rb.velocity = new Vector3(5,0,rb.velocity.z);
        //     rotationAmount = rotationSpeed * Time.deltaTime;
        //     transform.Rotate(Vector3.up, rotationAmount);

            Quaternion orbitRotation = Quaternion.Euler(0f, orbitSpeed * Time.deltaTime, 0f);
            Vector3 offset = transform.position - centerOfRotation.position;
            offset = orbitRotation * offset;
            transform.position = centerOfRotation.position + offset;

            // Keep x and z rotations constant
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.x = 0f;
            eulerAngles.z = 0f;
            transform.eulerAngles = eulerAngles;


            rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAmount);

        }
    }   
}
