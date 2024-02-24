using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public int KeyLock;
    public int byGarage;
    public GameObject GarageInterface;
    void Start()
    {
        KeyLock = 0;
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
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && KeyLock == 0){
            Vector3 forwardDirection = transform.forward;
            transform.Translate(forwardDirection * moveSpeed * Time.deltaTime, Space.World);
            Vector3 rightDirection = transform.right;
            transform.Translate(rightDirection * moveSpeed * Time.deltaTime, Space.World);

            Quaternion targetRotation = Quaternion.Lerp(Quaternion.LookRotation(forwardDirection), Quaternion.LookRotation(rightDirection), 0.5f); // This will make it look halfway between forward and left, adjust as needed
            // Apply the interpolated rotation to the child transform
            childTransform.rotation = targetRotation;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && KeyLock == 0){
            Vector3 forwardDirection = transform.forward;
            transform.Translate(forwardDirection * moveSpeed * Time.deltaTime, Space.World);
            Vector3 leftDirection = -transform.right;
            transform.Translate(leftDirection * moveSpeed * Time.deltaTime, Space.World);

            Quaternion targetRotation = Quaternion.Lerp(Quaternion.LookRotation(forwardDirection), Quaternion.LookRotation(leftDirection), 0.5f); // This will make it look halfway between forward and left, adjust as needed
            // Apply the interpolated rotation to the child transform
            childTransform.rotation = targetRotation;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && KeyLock == 0){
            Vector3 backwardDirection = -transform.forward;
            transform.Translate(backwardDirection * moveSpeed * Time.deltaTime, Space.World);
            Vector3 leftDirection = -transform.right;
            transform.Translate(leftDirection * moveSpeed * Time.deltaTime, Space.World);

            Quaternion targetRotation = Quaternion.Lerp(Quaternion.LookRotation(backwardDirection), Quaternion.LookRotation(leftDirection), 0.5f); // This will make it look halfway between forward and left, adjust as needed
            // Apply the interpolated rotation to the child transform
            childTransform.rotation = targetRotation;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && KeyLock == 0){
            Vector3 backwardDirection = -transform.forward;
            transform.Translate(backwardDirection * moveSpeed * Time.deltaTime, Space.World);
            Vector3 rightDirection = transform.right;
            transform.Translate(rightDirection * moveSpeed * Time.deltaTime, Space.World);

            Quaternion targetRotation = Quaternion.Lerp(Quaternion.LookRotation(backwardDirection), Quaternion.LookRotation(rightDirection), 0.5f); // This will make it look halfway between forward and left, adjust as needed
            // Apply the interpolated rotation to the child transform
            childTransform.rotation = targetRotation;
        }
        else{
            if (Input.GetKey(KeyCode.W) && KeyLock == 0){
                Vector3 forwardDirection = transform.forward;
                transform.Translate(forwardDirection * moveSpeed * Time.deltaTime, Space.World);

                if (childTransform != null)
                {
                    childTransform.rotation = Quaternion.LookRotation(forwardDirection);
                }
            }
            if (Input.GetKey(KeyCode.D) && KeyLock == 0){
                Vector3 rightDirection = transform.right;
                transform.Translate(rightDirection * moveSpeed * Time.deltaTime, Space.World);

                if (childTransform != null)
                {
                    childTransform.rotation = Quaternion.LookRotation(rightDirection);
                }
            }
            if (Input.GetKey(KeyCode.S) && KeyLock == 0){
                Vector3 backwardDirection = -transform.forward; // Get the backward direction relative to the character's current orientation
                transform.Translate(backwardDirection * moveSpeed * Time.deltaTime, Space.World);

                if (childTransform != null)
                {
                    childTransform.rotation = Quaternion.LookRotation(backwardDirection);
                }
            }
            if (Input.GetKey(KeyCode.A) && KeyLock == 0){
                Vector3 leftDirection = -transform.right;
                transform.Translate(leftDirection * moveSpeed * Time.deltaTime, Space.World);

                if (childTransform != null)
                {
                    childTransform.rotation = Quaternion.LookRotation(leftDirection);
                }
            }
        }
        if (Input.GetKey("left") && KeyLock == 0){
            //rb.velocity = new Vector3(-5,rb.velocity.y,rb.velocity.z);
            rotationAmount = rotationSpeed * Time.deltaTime;
            childTransform.Rotate(Vector3.up, rotationAmount);
            transform.Rotate(Vector3.up, -rotationAmount);
        }
        if (Input.GetKey("right") && KeyLock == 0){
            //rb.velocity = new Vector3(5,0,rb.velocity.z);
            rotationAmount = rotationSpeed * Time.deltaTime;
            childTransform.Rotate(Vector3.up, -rotationAmount);
            transform.Rotate(Vector3.up, rotationAmount);
        }
        // Vector3 parentPosition = transform.position;
        // carTransform.position = new Vector3(parentPosition.x, parentPosition.y, parentPosition.z + 10);
        if (Input.GetKeyDown(KeyCode.Q) && KeyLock == 0 && carGot.canSummon == 1){
                if(CarSummoned == 0){
                    CarSummoned = 1;
                    carGot.garageText.SetActive(false);
                }
                else if(CarSummoned == 1){
                    CarSummoned = 0;
                    if(byGarage == 1){
                        carGot.garageText.SetActive(true);
                    }
                }
                

        }

        if (Input.GetKeyDown(KeyCode.G) && byGarage == 1 && KeyLock == 0 && CarSummoned == 0){
            KeyLock = 1;
            carGot.garageText.SetActive(false);
            GarageInterface.SetActive(true);
            SetGarageInterface();
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
        if (other.CompareTag("Garage") && CarSummoned == 0) // Example: Checking if the triggering object has the "Player" tag
        {
            byGarage = 1;
            carGot.garageText.SetActive(true);
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
        if (other.CompareTag("Garage") && CarSummoned == 0) // Example: Checking if the triggering object has the "Player" tag
        {
            byGarage = 0;
            carGot.garageText.SetActive(false);
        }
    }  
    public void SetGarageInterface(){
                for (int i = 0; i < GarageInterface.transform.GetChild(0).childCount; i++){
                    Transform GarageChild = GarageInterface.transform.GetChild(0).GetChild(i);
                    if(i < 5){
                        if(carGot.gameObject.transform.GetChild(i).childCount > 0){
                            GarageChild.GetChild(0).gameObject.GetComponent<Image>().sprite = carGot.gameObject.transform.GetChild(i).GetChild(0).gameObject.GetComponent<CarMovement>().image.sprite;
                            Color imageColor = GarageChild.GetChild(0).gameObject.GetComponent<Image>().color;
                            imageColor.a = 1f;
                            GarageChild.GetChild(0).gameObject.GetComponent<Image>().color = imageColor;
                        }
                        else{
                            GarageChild.GetChild(0).gameObject.GetComponent<Image>().sprite = null;
                            Color imageColor = GarageChild.GetChild(0).gameObject.GetComponent<Image>().color;
                            imageColor.a = 0f;
                            GarageChild.GetChild(0).gameObject.GetComponent<Image>().color = imageColor;
                        }
                    }
                    else{
                        if(carGot.gameObject.transform.parent.GetChild(1).GetChild(i-5).childCount > 0){
                            GarageChild.GetChild(0).gameObject.GetComponent<Image>().sprite = carGot.gameObject.transform.parent.GetChild(1).GetChild(i-5).GetChild(0).gameObject.GetComponent<CarMovement>().image.sprite;
                            Color imageColor = GarageChild.GetChild(0).gameObject.GetComponent<Image>().color;
                            imageColor.a = 1f;
                            GarageChild.GetChild(0).gameObject.GetComponent<Image>().color = imageColor;
                        }
                        else{
                            GarageChild.GetChild(0).gameObject.GetComponent<Image>().sprite = null;
                            Color imageColor = GarageChild.GetChild(0).gameObject.GetComponent<Image>().color;
                            imageColor.a = 0f;
                            GarageChild.GetChild(0).gameObject.GetComponent<Image>().color = imageColor;
                        }
                    }
                } 
    }

    public void CloseGarage(){
        KeyLock = 0;
        byGarage = 0;
        GarageInterface.SetActive(false);
    }
}
