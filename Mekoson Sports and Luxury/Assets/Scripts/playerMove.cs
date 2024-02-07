using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    Rigidbody rb;
    public float rotationSpeed = 30f;
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
        
        if (Input.GetKeyDown("space")){
            rb.velocity = new Vector3(rb.velocity.x,5,rb.velocity.z);
        }
        if (Input.GetKey("up") || Input.GetKey(KeyCode.W)){
            //rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,5);
            transform.Translate(forwardDirection * moveSpeed * Time.deltaTime, Space.World);
            if (childTransform != null)
            {
                childTransform.rotation = Quaternion.LookRotation(Vector3.forward);
            }
        }
        if (Input.GetKey(KeyCode.D)){
            //rb.velocity = new Vector3(5,0,rb.velocity.z);
            transform.Translate(transform.right * moveSpeed * Time.deltaTime, Space.World);
            if (childTransform != null)
            {
                childTransform.rotation = Quaternion.LookRotation(Vector3.right);
            }
            //rotationAmount = rotationSpeed * Time.deltaTime;
            //transform.Rotate(Vector3.up, rotationAmount);
        }
        if (Input.GetKey("down") || Input.GetKey(KeyCode.S)){
            //rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,-5);
            transform.Translate(forwardDirection * -moveSpeed * Time.deltaTime, Space.World);
            if (childTransform != null)
            {
                childTransform.rotation = Quaternion.LookRotation(-Vector3.forward);
            }
        }
        if (Input.GetKey(KeyCode.A)){
            //rb.velocity = new Vector3(-5,rb.velocity.y,rb.velocity.z);
            transform.Translate(-transform.right * moveSpeed * Time.deltaTime, Space.World);
            if (childTransform != null)
            {
                childTransform.rotation = Quaternion.LookRotation(-Vector3.right);
            }
            //rotationAmount = rotationSpeed * Time.deltaTime;
            //transform.Rotate(Vector3.up, -rotationAmount);
        }
        if (Input.GetKey("left")){
            //rb.velocity = new Vector3(-5,rb.velocity.y,rb.velocity.z);
            rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, -rotationAmount);
        }
        if (Input.GetKey("right")){
            //rb.velocity = new Vector3(5,0,rb.velocity.z);
            rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAmount);
        }
    }   
}
