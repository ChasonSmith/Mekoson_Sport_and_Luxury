using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeCar : MonoBehaviour
{
    public float timeToBeat;
    public Vector3 TrackLocation;
    public int carIsChallenged;
    public Track1 track1;
    // Start is called before the first frame update
    void Start()
    {
        carIsChallenged = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
