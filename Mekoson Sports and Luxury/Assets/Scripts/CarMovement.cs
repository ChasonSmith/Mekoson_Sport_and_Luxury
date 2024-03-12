using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{   
    
    public enum ControlMode
    {
        Keyboard,
        Buttons
    };

    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public GameObject wheelEffectObj;
        public ParticleSystem smokeParticle;
        public Axel axel;
    }

    public ControlMode control;

    public float maxAcceleration;
    public float turnSensitivity;
    public float brakeAcceleration;
    public float defaultSpeed;
    public float defaultRotate;
    public float maxSteerAngle;
    public float cameraSpeed;
    public float grassMult;
    public float snowMult;
    public float asphaltMult;
    public float mudMult;
    public float desertMult;
    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    float moveInput;
    float steerInput;

    private Rigidbody carRb;
    
    
    
    //existed already
    Rigidbody rb;
    // The object to rotate around
    //public float rotationSpeed;
    //public float moveSpeed;
    
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
    
    public int onSnow;
    public int onAsphalt;
    public int onGrass;
    public int onMud;
    public int onDesert;
    public float currMult;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {

        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;


        currMult = 1;
        turnSensitivity = defaultRotate;
        maxAcceleration = defaultSpeed;
        inRace = 0;
        CarParent = transform.parent.parent;
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

        //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        GetInputs();
        AnimateWheels();
        //WheelEffects();

        // if(carTransform.transform.childCount > 0){
        //     carUsing = carTransform.GetChild(0);
        //     carUseRB = carUsing.GetComponent<Rigidbody>();
        // }
        // Move the object forward based on its forward direction
        
        // if (Input.GetKeyDown("space")){
        //     rb.velocity = new Vector3(rb.velocity.x,5,rb.velocity.z);
        // }
        turnSensitivity = defaultRotate * currMult;
        if(turnSensitivity > 180){
            turnSensitivity = 180;
        }
        maxAcceleration = defaultSpeed * currMult;
        if (transform.childCount > 1)
        {
            cameraTransform = transform.GetChild(0);
            childTransform = transform.GetChild(1);
            cameraTransform.gameObject.SetActive(true);
            //carTransform = transform.GetChild(3);
        }

        
        //     if (Input.GetKey(KeyCode.W)){
        //         Vector3 forwardDirection = transform.forward;
        //         transform.Translate(forwardDirection * moveSpeed * Time.deltaTime, Space.World);

        //         if (childTransform != null)
        //         {
        //             childTransform.rotation = Quaternion.LookRotation(forwardDirection);
        //         }
        //     }
        //     if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)){
        //         // Vector3 rightDirection = transform.right;
        //         // transform.Translate(rightDirection * moveSpeed * Time.deltaTime, Space.World);
        //         rotationAmount = rotationSpeed * Time.deltaTime;
        //         childTransform.Rotate(Vector3.up, -rotationAmount);
        //         transform.Rotate(Vector3.up, rotationAmount);
        //         // if (childTransform != null)
        //         // {
        //         //     childTransform.rotation = Quaternion.LookRotation(rightDirection);
        //         // }
        //     }
        //     if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)){
        //         // Vector3 rightDirection = transform.right;
        //         // transform.Translate(rightDirection * moveSpeed * Time.deltaTime, Space.World);
        //         rotationAmount = rotationSpeed * Time.deltaTime;
        //         childTransform.Rotate(Vector3.up, rotationAmount);
        //         transform.Rotate(Vector3.up, -rotationAmount);
        //         // if (childTransform != null)
        //         // {
        //         //     childTransform.rotation = Quaternion.LookRotation(rightDirection);
        //         // }
        //     }
        //     if (Input.GetKey(KeyCode.S)){
        //         Vector3 backwardDirection = -transform.forward; // Get the backward direction relative to the character's current orientation
        //         Vector3 forwardDirection = transform.forward;
        //         transform.Translate(backwardDirection * moveSpeed * Time.deltaTime, Space.World);

        //         if (childTransform != null)
        //         {
        //             childTransform.rotation = Quaternion.LookRotation(forwardDirection);
        //         }
        //     }
        //     if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)){
        //         // Vector3 leftDirection = -transform.right;
        //         // transform.Translate(leftDirection * moveSpeed * Time.deltaTime, Space.World);
        //         rotationAmount = rotationSpeed * Time.deltaTime;
        //         childTransform.Rotate(Vector3.up, rotationAmount);
        //         transform.Rotate(Vector3.up, -rotationAmount);
        //         // if (childTransform != null)
        //         // {
        //         //     childTransform.rotation = Quaternion.LookRotation(leftDirection);
        //         // }
        //     }
        //     if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)){
        //         // Vector3 leftDirection = -transform.right;
        //         // transform.Translate(leftDirection * moveSpeed * Time.deltaTime, Space.World);
        //         rotationAmount = rotationSpeed * Time.deltaTime;
        //         childTransform.Rotate(Vector3.up, -rotationAmount);
        //         transform.Rotate(Vector3.up, rotationAmount);
        //         // if (childTransform != null)
        //         // {
        //         //     childTransform.rotation = Quaternion.LookRotation(leftDirection);
        //         // }
        //     }
        
        if (Input.GetKey("left")){
            //rb.velocity = new Vector3(-5,rb.velocity.y,rb.velocity.z);
            rotationAmount = cameraSpeed * Time.deltaTime;
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
            rotationAmount = cameraSpeed * Time.deltaTime;
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

        // if (Input.GetKey(KeyCode.R)){
        //     transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        // }
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
        else if(onMud == 1){
            currMult = mudMult;
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
        if (other.CompareTag("Garage")) // Example: Checking if the triggering object has the "Player" tag
        {
            CarParent.gameObject.GetComponent<PlayerSummon>().garageText.SetActive(false);
            CarParent.gameObject.GetComponent<PlayerSummon>().player.GetComponent<playerMove>().byGarage = 0;
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
            if(material.name == "asphalt (Instance)" || material.name == "Road2 (Instance)"){
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

    //new
    void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }

    public void MoveInput(float input)
    {
        moveInput = input;
    }

    public void SteerInput(float input)
    {
        steerInput = input;
    }

    void GetInputs()
    {
        if(control == ControlMode.Keyboard)
        {
            moveInput = Input.GetAxis("Vertical");
            steerInput = Input.GetAxis("Horizontal");
        }
    }

    void Move()
    {
        foreach(var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * 600 * maxAcceleration * Time.deltaTime;
        }
    }

    void Steer()
    {
        foreach(var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    void Brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 600 * brakeAcceleration * Time.deltaTime;
            }

            //carLights.isBackLightOn = true;
            //carLights.OperateBackLights();
        }
        else if (moveInput == 0)
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime;
            }

            //carLights.isBackLightOn = true;
            //carLights.OperateBackLights();
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }

            //carLights.isBackLightOn = false;
            //carLights.OperateBackLights();
        }
    }

    void AnimateWheels()
    {
        foreach(var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }

    void WheelEffects()
    {
        foreach (var wheel in wheels)
        {
            //var dirtParticleMainSettings = wheel.smokeParticle.main;

            if (Input.GetKey(KeyCode.Space) && wheel.axel == Axel.Rear && wheel.wheelCollider.isGrounded == true && carRb.velocity.magnitude >= 10.0f)
            {
                wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = true;
                wheel.smokeParticle.Emit(1);
            }
            else
            {
                wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = false;
            }
        }
    }

  
}
