using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check3 : MonoBehaviour
{
    public Track1 track1;
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
        if (other.CompareTag("Driveable") && track1.checkVal == 1) // Example: Checking if the triggering object has the "Player" tag
        {
            track1.checkVal = 2;
        }
    }
}
