using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSummon : MonoBehaviour
{
    public GameObject followThis;
    public int CarSummoned;
    public Transform carToDrive;
    public int carChosen;
    public playerMove refrencePos;
    Vector3 refPosition;
    public GameObject driveText;
    public GameObject challengeText;
    public GameObject garageText;
    public int canDrive;
    public int inCar;
    public GameObject player;
    public Transform cameraTransform;
    public GameObject track1Text;
    public GameObject timeTextImage;
    public TextMeshProUGUI timeText;
    public GameObject lapTextImage;
    public TextMeshProUGUI lapText;
    public int carToDriveIndex;
    public int canSummon;
    // Start is called before the first frame update
    void Start()
    {
        canSummon = 1;
        carToDriveIndex = 0;
        inCar = 0;
        canDrive = 0;
        CarSummoned = 0;
        carChosen = 0;
        if (transform.childCount > carToDriveIndex)
        {
            carToDrive = transform.GetChild(carToDriveIndex);
            //carTransform = transform.GetChild(3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > carToDriveIndex)
        {
            carToDrive = transform.GetChild(carToDriveIndex);
            canSummon = 1;
            //carTransform = transform.GetChild(3);
        }
        else{
            canSummon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Q) && canSummon == 1 && player.GetComponent<playerMove>().KeyLock == 0){
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
                    CarOutRangeDrive();
                }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1) && CarSummoned == 0){
            if (transform.childCount > 0){
                carToDriveIndex = 0;
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && CarSummoned == 0){
            if (transform.childCount > 1){
                carToDriveIndex = 1;
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && CarSummoned == 0){
            if (transform.childCount > 2){
                carToDriveIndex = 2;
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha4) && CarSummoned == 0){
            if (transform.childCount > 3){
                carToDriveIndex = 3;
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha5) && CarSummoned == 0){
            if (transform.childCount > 4){
                carToDriveIndex = 4;
            }
        }

        if(inCar == 1){
            if(Input.GetKeyUp(KeyCode.X) && carToDrive.gameObject.GetComponent<CarMovement>().inRace == 0){
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
            if(Input.GetKeyUp(KeyCode.X)){
                driveText.SetActive(false);
                inCar = 1;
                player.SetActive(false);
                carToDrive.gameObject.GetComponent<CarMovement>().enabled = true;
            }
        }

        
        
    }

    public void CarInRangeDrive()
    {
        driveText.SetActive(true);
        canDrive = 1;

    }

    public void CarOutRangeDrive()
    {
        driveText.SetActive(false);
        canDrive = 0;
    }

    public void runTimer(int minutes, int seconds, int milliseconds){
        timeTextImage.SetActive(true);
        timeText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }

    public void closeTimer(){
        timeTextImage.SetActive(false);
    }

    public void openLapCount(int lapsDone, int lapsNeeded){
        lapTextImage.SetActive(true);
        int lapsDonetext = lapsDone + 1;
        lapText.text = string.Format("Lap: {0}/{1}", lapsDonetext, lapsNeeded);
    }

    public void closeLapCount(){
        lapTextImage.SetActive(false);
    }


    
}
