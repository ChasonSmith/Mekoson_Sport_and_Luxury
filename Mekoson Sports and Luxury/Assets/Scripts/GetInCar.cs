using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInCar : MonoBehaviour
{
    public PlayerSummon carGot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hello, Unity!");
        // if(CarSummoned == 1){
        //     if (other.CompareTag("Player")) // Example: Checking if the triggering object has the "Player" tag
        //     {
        //         driveText.SetActive(true);
        //         // Add your code here to handle the trigger entering event
        //     }
        // }
    }

    private void OnTriggerExit(Collider other)
    {
        // if(CarSummoned == 1){
        //     if (other.CompareTag("Player")) // Example: Checking if the triggering object has the "Player" tag
        //     {
        //         driveText.SetActive(false);
        //         // Add your code here to handle the trigger entering event
        //     }
        // }
    }
}
