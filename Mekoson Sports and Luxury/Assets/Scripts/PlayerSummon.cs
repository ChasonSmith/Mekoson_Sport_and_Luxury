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
    int canDrive;
    int inCar;
    public GameObject player;
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
                    CarSummoned = 1;
                }
                else if(CarSummoned == 1){
                    carToDrive.gameObject.SetActive(false);
                    CarSummoned = 0;
                }
        }

        if(canDrive == 1){
            if(Input.GetKeyDown(KeyCode.X)){
                driveText.SetActive(false);
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
