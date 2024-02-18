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
    //Transform carTransform;
    //Transform carUsing;
    int CarSummoned;
    public PlayerSummon carGot;
    //Rigidbody carUseRB;
    // Start is called before the first frame update
    void Start()
    {
        CarSummoned = 0;
        rb = GetComponent<Rigidbody>();
        if (transform.childCount > 0)
        {
            childTransform = transform.GetChild(1);
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
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)){
            Vector3 forwardDirection = transform.forward;
            transform.Translate(forwardDirection * moveSpeed * Time.deltaTime, Space.World);
            Vector3 rightDirection = transform.right;
            transform.Translate(rightDirection * moveSpeed * Time.deltaTime, Space.World);

            Quaternion targetRotation = Quaternion.Lerp(Quaternion.LookRotation(forwardDirection), Quaternion.LookRotation(rightDirection), 0.5f); // This will make it look halfway between forward and left, adjust as needed
            // Apply the interpolated rotation to the child transform
            childTransform.rotation = targetRotation;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)){
            Vector3 forwardDirection = transform.forward;
            transform.Translate(forwardDirection * moveSpeed * Time.deltaTime, Space.World);
            Vector3 leftDirection = -transform.right;
            transform.Translate(leftDirection * moveSpeed * Time.deltaTime, Space.World);

            Quaternion targetRotation = Quaternion.Lerp(Quaternion.LookRotation(forwardDirection), Quaternion.LookRotation(leftDirection), 0.5f); // This will make it look halfway between forward and left, adjust as needed
            // Apply the interpolated rotation to the child transform
            childTransform.rotation = targetRotation;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)){
            Vector3 backwardDirection = -transform.forward;
            transform.Translate(backwardDirection * moveSpeed * Time.deltaTime, Space.World);
            Vector3 leftDirection = -transform.right;
            transform.Translate(leftDirection * moveSpeed * Time.deltaTime, Space.World);

            Quaternion targetRotation = Quaternion.Lerp(Quaternion.LookRotation(backwardDirection), Quaternion.LookRotation(leftDirection), 0.5f); // This will make it look halfway between forward and left, adjust as needed
            // Apply the interpolated rotation to the child transform
            childTransform.rotation = targetRotation;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)){
            Vector3 backwardDirection = -transform.forward;
            transform.Translate(backwardDirection * moveSpeed * Time.deltaTime, Space.World);
            Vector3 rightDirection = transform.right;
            transform.Translate(rightDirection * moveSpeed * Time.deltaTime, Space.World);

            Quaternion targetRotation = Quaternion.Lerp(Quaternion.LookRotation(backwardDirection), Quaternion.LookRotation(rightDirection), 0.5f); // This will make it look halfway between forward and left, adjust as needed
            // Apply the interpolated rotation to the child transform
            childTransform.rotation = targetRotation;
        }
        else{
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
        }
        if (Input.GetKey("left")){
            //rb.velocity = new Vector3(-5,rb.velocity.y,rb.velocity.z);
            rotationAmount = rotationSpeed * Time.deltaTime;
            childTransform.Rotate(Vector3.up, rotationAmount);
            transform.Rotate(Vector3.up, -rotationAmount);
        }
        if (Input.GetKey("right")){
            //rb.velocity = new Vector3(5,0,rb.velocity.z);
            rotationAmount = rotationSpeed * Time.deltaTime;
            childTransform.Rotate(Vector3.up, -rotationAmount);
            transform.Rotate(Vector3.up, rotationAmount);
        }
        // Vector3 parentPosition = transform.position;
        // carTransform.position = new Vector3(parentPosition.x, parentPosition.y, parentPosition.z + 10);
        if (Input.GetKeyDown(KeyCode.Q)){
                if(CarSummoned == 0){
                    CarSummoned = 1;
                }
                else if(CarSummoned == 1){
                    CarSummoned = 0;
                }
                

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hello, Unity!");
        if(carGot.CarSummoned == 1){
            if (other.CompareTag("Driveable")) // Example: Checking if the triggering object has the "Player" tag
            {
                carGot.CarInRangeDrive();
                // Add your code here to handle the trigger entering event
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(carGot.CarSummoned == 1){
            if (other.CompareTag("Driveable")) // Example: Checking if the triggering object has the "Player" tag
            {
                carGot.CarOutRangeDrive();
                // Add your code here to handle the trigger entering event
            }
        }
    }   
}
