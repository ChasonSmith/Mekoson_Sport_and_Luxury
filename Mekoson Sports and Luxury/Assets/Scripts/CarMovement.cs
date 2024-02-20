using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    Rigidbody rb;
    // The object to rotate around
    public float rotationSpeed;
    public float moveSpeed;
    float rotationAmount;
    Transform cameraTransform;
    Transform childTransform;
    public int canChallenge;
    public Transform CarParent;
    public int inRace;
    public GameObject CarBeingChallenged;
    public float timeToBeat;
    public float raceTime;
    public Vector3 positionWhereChallenge;
    int minutes;
    int seconds;
    int milliseconds;
    public int wonChallenge;
    public int lapsDone;
    public int lapsNeeded;
    public float defaultSpeed;
    public float defaultRotate;
    public float grassMult;
    public float snowMult;
    public float asphaltMult;
    public float mudMult;
    public float desertMult;
    public int onSnow;
    public int onAsphalt;
    public int onGrass;
    public int onMud;
    public int onDesert;
    public float currMult;
    // Start is called before the first frame update
    void Start()
    {
        currMult = 1;
        rotationSpeed = defaultRotate;
        moveSpeed = defaultSpeed;
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
        rotationSpeed = defaultRotate * currMult;
        if(rotationSpeed > 180){
            rotationSpeed = 180;
        }
        moveSpeed = defaultSpeed * currMult;
        if(rotationSpeed > 180){
            rotationSpeed = 180;
        }
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
                canChallenge = 0;
                CarParent.gameObject.GetComponent<PlayerSummon>().challengeText.SetActive(false);
                positionWhereChallenge = transform.position;
                transform.rotation = Quaternion.Euler(Vector3.zero);
                transform.position = CarBeingChallenged.GetComponent<ChallengeCar>().TrackLocation;
                inRace = 1;
                timeToBeat = CarBeingChallenged.GetComponent<ChallengeCar>().timeToBeat;
                CarBeingChallenged.GetComponent<ChallengeCar>().carIsChallenged = 1;
                lapsNeeded = CarBeingChallenged.GetComponent<ChallengeCar>().track1.lapsNeeded;

            }
        }

        if(inRace ==1){
            minutes = Mathf.FloorToInt(timeToBeat / 60);
            seconds = Mathf.FloorToInt(timeToBeat % 60);
            milliseconds = Mathf.FloorToInt((timeToBeat - Mathf.Floor(timeToBeat)) * 100);
            lapsDone = CarBeingChallenged.GetComponent<ChallengeCar>().track1.lapsDone;
            CarParent.gameObject.GetComponent<PlayerSummon>().runTimer(minutes, seconds, milliseconds);
            CarParent.gameObject.GetComponent<PlayerSummon>().openLapCount(lapsDone, lapsNeeded);
            timeToBeat -= Time.deltaTime;
            
            if(timeToBeat <= 0){
                timeToBeat = 0;
                inRace = 0;
                lapsDone = 0;
                CarBeingChallenged.GetComponent<ChallengeCar>().track1.lapsDone = 0;
                transform.position = positionWhereChallenge;
                Destroy(CarBeingChallenged);
                CarParent.gameObject.GetComponent<PlayerSummon>().closeTimer();
                CarParent.gameObject.GetComponent<PlayerSummon>().closeLapCount();
            }

            if(lapsDone == lapsNeeded){
                timeToBeat = 0;
                inRace = 0;
                lapsDone = 0;
                CarBeingChallenged.GetComponent<ChallengeCar>().track1.lapsDone = 0;
                transform.position = positionWhereChallenge;
                CarBeingChallenged.GetComponent<ChallengeCar>().enabled = false;
                CarBeingChallenged.tag = "Driveable";
                CarBeingChallenged.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                CarBeingChallenged.GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                CarBeingChallenged = null;
                CarParent.gameObject.GetComponent<PlayerSummon>().closeTimer();
                CarParent.gameObject.GetComponent<PlayerSummon>().closeLapCount();
            }
        }

        if(CarBeingChallenged == null){
            canChallenge = 0;
            CarParent.gameObject.GetComponent<PlayerSummon>().challengeText.SetActive(false);
        }

        if(onAsphalt == 1){
            currMult = asphaltMult;
        }
        else if(onGrass == 1){
            currMult = grassMult;
        }
        else if(onDesert == 1){
            currMult = desertMult;
        }
        else if(onSnow == 1){
            currMult = snowMult;
        }
        else if(onMud == 1){
            currMult = mudMult;
        }
        else{
            currMult = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hello, Unity!");
        if (other.CompareTag("AiCar")) // Example: Checking if the triggering object has the "Player" tag
        {
            CarParent.gameObject.GetComponent<PlayerSummon>().challengeText.SetActive(true);
            canChallenge = 1;
            CarBeingChallenged = other.gameObject;
            // Add your code here to handle the trigger entering event
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AiCar")) // Example: Checking if the triggering object has the "Player" tag
        {
            CarParent.gameObject.GetComponent<PlayerSummon>().challengeText.SetActive(false);
            canChallenge = 0;
            //line below may be needed not sure yet
            //CarBeingChallenged = other.gameObject;
            // Add your code here to handle the trigger entering event
        }
        if (other.CompareTag("Desert")) // Example: Checking if the triggering object has the "Player" tag
        {
            onDesert = 0;
        }
        if (other.CompareTag("Asphalt")) // Example: Checking if the triggering object has the "Player" tag
        {
            onAsphalt = 0;
        }
        if (other.CompareTag("Grass")) // Example: Checking if the triggering object has the "Player" tag
        {
            onGrass = 0;
        }
        if (other.CompareTag("Snow")) // Example: Checking if the triggering object has the "Player" tag
        {
            onSnow = 0;
        }
        if (other.CompareTag("Mud")) // Example: Checking if the triggering object has the "Player" tag
        {
            onMud = 0;
        }
    }  

    void OnTriggerStay(Collider other)
    {
        // Check if the collider we're colliding with has a renderer
        Renderer renderer = other.GetComponent<Renderer>();
        if (renderer != null)
        {
            // Get the material of the ground
            Material material = renderer.material;
            //Debug.Log(material.name);
            if(material.name == "asphalt (Instance)"){
                onAsphalt = 1;
            }
            else if(material.name == "grass (Instance)"){
                onGrass = 1;
            }
            else if(material.name == "desert (Instance)"){
                onDesert = 1;
            }
            else if(material.name == "snow (Instance)"){
                onSnow = 1;
            }
            else if(material.name == "mud (Instance)"){
                onMud = 1;
            }
        }
    }

  
}
