using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawn : MonoBehaviour
{
    public int leaveToRace;
    Transform spawnRC;
    // Start is called before the first frame update
    void Start()
    {
        leaveToRace = 0;
        spawnRC = gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other){
        if (other.CompareTag("Driveable")) // Example: Checking if the triggering object has the "Player" tag
        {
            //Debug.Log(leaveToRace);
            if(leaveToRace == 0){
                if(spawnRC.gameObject.GetComponent<Spawner>().carIsSpawned == 1){
                    Destroy(spawnRC.gameObject.GetComponent<Spawner>().spawnedCar);
                    spawnRC.gameObject.GetComponent<Spawner>().carIsSpawned = 0;
                }
            }
            else{
                leaveToRace -= 1;
            }
        }
    }
}
