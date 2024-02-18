using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    Rigidbody rb;
    // The object to rotate around
    public float rotationSpeed = 45f;
    public float moveSpeed = 50f;
    float rotationAmount;
    Transform cameraTransform;
    Transform childTransform;
    public int canChallenge;
    public Transform CarParent;
    public int inRace;
    // Start is called before the first frame update
    void Start()
    {
        inRace = 0;
        CarParent = transform.parent;
        canChallenge = 0;
        rb = GetComponent<Rigidbody>();
        if (transform.childCount > 1)
        {
            cameraTransform = transform.GetChild(0);
            childTransform = transform.GetChild(1);
            cameraTransform.gameObject.SetActive(true);
            //carTransform = transform.GetChild(3);
        }
    }

    // Update is called once per frame
    void Update()
    {

        // if(carTransform.transform.childCount > 0){
        //     carUsing = carTransform.GetChild(0);
        //     carUseRB = carUsing.GetComponent<Rigidbody>();
        // }
        // Move the object forward based on its forward direction
        
        // if (Input.GetKeyDown("space")){
        //     rb.velocity = new Vector3(rb.velocity.x,5,rb.velocity.z);
        // }

        if (transform.childCount > 1)
        {
            cameraTransform = transform.GetChild(0);
            childTransform = transform.GetChild(1);
            cameraTransform.gameObject.SetActive(true);
            //carTransform = transform.GetChild(3);
        }
            if (Input.GetKey(KeyCode.W)){
                Vector3 forwardDirection = transform.forward;
                transform.Translate(forwardDirection * moveSpeed * Time.deltaTime, Space.World);

                if (childTransform != null)
                {
                    childTransform.rotation = Quaternion.LookRotation(forwardDirection);
                }
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)){
                // Vector3 rightDirection = transform.right;
                // transform.Translate(rightDirection * moveSpeed * Time.deltaTime, Space.World);
                rotationAmount = rotationSpeed * Time.deltaTime;
                childTransform.Rotate(Vector3.up, -rotationAmount);
                transform.Rotate(Vector3.up, rotationAmount);
                // if (childTransform != null)
                // {
                //     childTransform.rotation = Quaternion.LookRotation(rightDirection);
                // }
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)){
                // Vector3 rightDirection = transform.right;
                // transform.Translate(rightDirection * moveSpeed * Time.deltaTime, Space.World);
                rotationAmount = rotationSpeed * Time.deltaTime;
                childTransform.Rotate(Vector3.up, rotationAmount);
                transform.Rotate(Vector3.up, -rotationAmount);
                // if (childTransform != null)
                // {
                //     childTransform.rotation = Quaternion.LookRotation(rightDirection);
                // }
            }
            if (Input.GetKey(KeyCode.S)){
                Vector3 backwardDirection = -transform.forward; // Get the backward direction relative to the character's current orientation
                Vector3 forwardDirection = transform.forward;
                transform.Translate(backwardDirection * moveSpeed * Time.deltaTime, Space.World);

                if (childTransform != null)
                {
                    childTransform.rotation = Quaternion.LookRotation(forwardDirection);
                }
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)){
                // Vector3 leftDirection = -transform.right;
                // transform.Translate(leftDirection * moveSpeed * Time.deltaTime, Space.World);
                rotationAmount = rotationSpeed * Time.deltaTime;
                childTransform.Rotate(Vector3.up, rotationAmount);
                transform.Rotate(Vector3.up, -rotationAmount);
                // if (childTransform != null)
                // {
                //     childTransform.rotation = Quaternion.LookRotation(leftDirection);
                // }
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)){
                // Vector3 leftDirection = -transform.right;
                // transform.Translate(leftDirection * moveSpeed * Time.deltaTime, Space.World);
                rotationAmount = rotationSpeed * Time.deltaTime;
                childTransform.Rotate(Vector3.up, -rotationAmount);
                transform.Rotate(Vector3.up, rotationAmount);
                // if (childTransform != null)
                // {
                //     childTransform.rotation = Quaternion.LookRotation(leftDirection);
                // }
            }
        
        if (Input.GetKey("left")){
            //rb.velocity = new Vector3(-5,rb.velocity.y,rb.velocity.z);
            rotationAmount = rotationSpeed * Time.deltaTime;
            //cameraTransform.Rotate(Vector3.up, -rotationAmount);
            cameraTransform.RotateAround(transform.position, transform.up, -rotationAmount);
            float originalXRotation = cameraTransform.eulerAngles.x;
            float originalZRotation = cameraTransform.eulerAngles.z;
            // Offset the camera's local position relative to its parent
            cameraTransform.LookAt(transform);
            Vector3 newRotation = cameraTransform.eulerAngles;
            newRotation.x = originalXRotation;
            newRotation.z = originalZRotation;
            cameraTransform.eulerAngles = newRotation;
        }
        if (Input.GetKey("right")){
            //rb.velocity = new Vector3(5,0,rb.velocity.z);
            rotationAmount = rotationSpeed * Time.deltaTime;
            //cameraTransform.Rotate(Vector3.up, -rotationAmount);
            cameraTransform.RotateAround(transform.position, transform.up, rotationAmount);
            float originalXRotation = cameraTransform.eulerAngles.x;
            float originalZRotation = cameraTransform.eulerAngles.z;
            // Offset the camera's local position relative to its parent
            cameraTransform.LookAt(transform);
            Vector3 newRotation = cameraTransform.eulerAngles;
            newRotation.x = originalXRotation;
            newRotation.z = originalZRotation;
            cameraTransform.eulerAngles = newRotation;
        }
        // Vector3 parentPosition = transform.position;
        // carTransform.position = new Vector3(parentPosition.x, parentPosition.y, parentPosition.z + 10);

        if (Input.GetKey(KeyCode.C)){
            if(canChallenge == 1){
                CarParent.gameObject.GetComponent<PlayerSummon>().challengeText.SetActive(false);
                transform.rotation = Quaternion.Euler(Vector3.zero);
                transform.position = new Vector3(10000f, 0f, 0f);
                inRace = 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hello, Unity!");
        if (other.CompareTag("AiCar")) // Example: Checking if the triggering object has the "Player" tag
        {
            CarParent.gameObject.GetComponent<PlayerSummon>().challengeText.SetActive(true);
            canChallenge = 1;
            // Add your code here to handle the trigger entering event
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AiCar")) // Example: Checking if the triggering object has the "Player" tag
        {
            CarParent.gameObject.GetComponent<PlayerSummon>().challengeText.SetActive(false);
            canChallenge = 0;
            // Add your code here to handle the trigger entering event
        }
    }  

  
}
