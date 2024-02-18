using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSummon : MonoBehaviour
{
    public GameObject followThis;
    public int CarSummoned;
    public Transform carToDrive;
    public int carChosen;
    public playerMove refrencePos;
    Vector3 refPosition;
    public GameObject driveText;
    public int canDrive;
    public int inCar;
    public GameObject player;
    public Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        inCar = 0;
        canDrive = 0;
        CarSummoned = 0;
        carChosen = 0;
        if (transform.childCount > 0)
        {
            carToDrive = transform.GetChild(0);
            //carTransform = transform.GetChild(3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
        {
            carToDrive = transform.GetChild(0);
            //carTransform = transform.GetChild(3);
        }

        if (Input.GetKeyDown(KeyCode.Q)){
                if(CarSummoned == 0){
                    carToDrive.gameObject.SetActive(true);
                    refPosition = refrencePos.transform.position + refrencePos.transform.forward * 5;
                    transform.position = refPosition;
                    Vector3 newPosition = carToDrive.localPosition;
                    newPosition.x = 0f;
                    newPosition.z = 0f;
                    carToDrive.localPosition = newPosition;
                    carToDrive.rotation = Quaternion.identity;
                    CarSummoned = 1;
                }
                else if(CarSummoned == 1 && inCar == 0){
                    carToDrive.gameObject.SetActive(false);
                    CarSummoned = 0;
                    CarOutRange();
                }
        }

        if(inCar == 1){
            if(Input.GetKeyDown(KeyCode.E)){
                //driveText.SetActive(false);
                carToDrive.gameObject.GetComponent<CarMovement>().enabled = false;
                cameraTransform = carToDrive.GetChild(0);
                cameraTransform.gameObject.SetActive(false);
                player.SetActive(true);
                //player.transform.position
                Vector3 carPosition = carToDrive.transform.position;
                Quaternion carRotation = carToDrive.transform.rotation;
                Vector3 offset = -carToDrive.transform.right * 5f;
                Vector3 playerPosition = carPosition + carRotation * offset;
                player.transform.position = playerPosition;
                inCar = 0;
                canDrive = 0;
            }
        }

        if(canDrive == 1){
            if(Input.GetKeyDown(KeyCode.X)){
                driveText.SetActive(false);
                inCar = 1;
                player.SetActive(false);
                carToDrive.gameObject.GetComponent<CarMovement>().enabled = true;
            }
        }

        
        
    }

    public void CarInRange()
    {
        driveText.SetActive(true);
        canDrive = 1;

    }

    public void CarOutRange()
    {
        driveText.SetActive(false);
        canDrive = 0;
    }

    
}
