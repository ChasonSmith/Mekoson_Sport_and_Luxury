using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject carToSpawn;
    public int spawnNum;
    public GameObject spawnedCar;
    public int carIsSpawned;
    public Transform parent;
    public GameObject newParentObject1;
    public GameObject newParentObject2;
    public Track1 track1;
    int foundParent;
    public int carWasWon;
    public int challengeReturn;
    // Start is called before the first frame update
    void Awake()
    {
        //SetSpawnTime();
    }
    void Start()
    {
        foundParent = 0;
        carIsSpawned = 0;
        carWasWon = 0;
        challengeReturn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(carWasWon == 1){
            if(carIsSpawned == 1){
                if(spawnedCar.GetComponent<ChallengeCar>().carIsChallenged == 1){
                    for (int i = 0; i < newParentObject1.transform.childCount; i++){
                        if(newParentObject1.transform.GetChild(i).childCount == 0){
                            spawnedCar.transform.SetParent(newParentObject1.transform.GetChild(i));
                            foundParent = 1;
                            break;
                        }
                    }
                    if(foundParent == 0){
                        for (int i = 0; i < newParentObject2.transform.childCount; i++){
                            if(newParentObject2.transform.GetChild(i).childCount == 0){
                                spawnedCar.transform.SetParent(newParentObject2.transform.GetChild(i));
                                //foundParent = 1;
                                break;
                            }
                        }
                    }
                    spawnedCar.SetActive(false);
                    carIsSpawned = 0;
                    carWasWon = 0;
                }
            }
        }

    }



    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Driveable")) // Example: Checking if the triggering object has the "Player" tag
        {
            //Debug.Log(challengeReturn);
            if(challengeReturn == 0){
                if(carIsSpawned == 0){
                    spawnedCar = Instantiate(carToSpawn,parent);
                    spawnedCar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    spawnedCar.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
                    spawnedCar.GetComponent<ChallengeCar>().enabled = true;
                    spawnedCar.GetComponent<ChallengeCar>().track1 = track1;
                    spawnedCar.tag = "AiCar";
                    carIsSpawned = 1;
                    //Debug.Log("enter");
                }
            }
            else{
                challengeReturn -= 1;
            }
        }
    }
}
