using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    Rigidbody rb;
    // The object to rotate around
    public float rotationSpeed = 45f;
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

        // Move the object forward based on its forward direction
        
        // if (Input.GetKeyDown("space")){
        //     rb.velocity = new Vector3(rb.velocity.x,5,rb.velocity.z);
        // }
        if (Input.GetKey(KeyCode.W)){
            Vector3 forwardDirection = transform.forward;
            transform.Translate(forwardDirection * moveSpeed * Time.deltaTime, Space.World);

            if (childTransform != null)
            {
                childTransform.rotation = Quaternion.LookRotation(forwardDirection);
            }
        }
        if (Input.GetKey(KeyCode.D)){
            Vector3 rightDirection = transform.right;
            transform.Translate(rightDirection * moveSpeed * Time.deltaTime, Space.World);

            if (childTransform != null)
            {
                childTransform.rotation = Quaternion.LookRotation(rightDirection);
            }
        }
        if (Input.GetKey(KeyCode.S)){
            Vector3 backwardDirection = -transform.forward; // Get the backward direction relative to the character's current orientation
            transform.Translate(backwardDirection * moveSpeed * Time.deltaTime, Space.World);

            if (childTransform != null)
            {
                childTransform.rotation = Quaternion.LookRotation(backwardDirection);
            }
        }
        if (Input.GetKey(KeyCode.A)){
            Vector3 leftDirection = -transform.right;
            transform.Translate(leftDirection * moveSpeed * Time.deltaTime, Space.World);

            if (childTransform != null)
            {
                childTransform.rotation = Quaternion.LookRotation(leftDirection);
            }
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
