using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject carToSpawn;
    public float minSpawnTime;
    public float maxSpawnTime;
    public float timeToSpawnCounter;
    public float timeToSpawn;
    public int spawnChance; // 1 in x chance
    public int spawnNum;
    GameObject spawnedCar;
    public int carIsSpawned;
    public Transform parent;
    public GameObject newParentObject1;
    public GameObject newParentObject2;
    public Track1 track1;
    // Start is called before the first frame update
    void Awake()
    {
        //SetSpawnTime();
    }
    void Start()
    {
        carIsSpawned = 0;
        timeToSpawn = timeToSpawnCounter;
    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawnCounter -= Time.deltaTime;
        if(timeToSpawnCounter <= 0){
            timeToSpawnCounter = timeToSpawn;
            spawnNum = Random.Range(1,spawnChance + 1);
            if( spawnNum == 1){
                if(carIsSpawned == 0){
                    spawnedCar = Instantiate(carToSpawn,parent);
                    spawnedCar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    spawnedCar.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
                    spawnedCar.GetComponent<ChallengeCar>().enabled = true;
                    spawnedCar.GetComponent<ChallengeCar>().track1 = track1;
                    spawnedCar.tag = "AiCar";
                    carIsSpawned = 1;
                }
                else if(carIsSpawned == 1){
                    Destroy(spawnedCar);
                    carIsSpawned = 0;
                }
            }
        }
        if(carIsSpawned == 1){
            if(spawnedCar.GetComponent<ChallengeCar>().carIsChallenged == 1){
                if(newParentObject1.transform.GetChild(0).gameObject.tag == "PlaceHolder"){
                    Destroy(newParentObject1.transform.GetChild(0).gameObject);
                    spawnedCar.transform.SetParent(newParentObject1.transform);
                    spawnedCar.transform.SetSiblingIndex(0);
                }
                else if(newParentObject1.transform.GetChild(1).gameObject.tag == "PlaceHolder"){
                    Destroy(newParentObject1.transform.GetChild(1).gameObject);
                    spawnedCar.transform.SetParent(newParentObject1.transform);
                    spawnedCar.transform.SetSiblingIndex(1);
                }
                else if(newParentObject1.transform.GetChild(2).gameObject.tag == "PlaceHolder"){
                    Destroy(newParentObject1.transform.GetChild(2).gameObject);
                    spawnedCar.transform.SetParent(newParentObject1.transform);
                    spawnedCar.transform.SetSiblingIndex(2);
                }
                else if(newParentObject1.transform.GetChild(3).gameObject.tag == "PlaceHolder"){
                    Destroy(newParentObject1.transform.GetChild(3).gameObject);
                    spawnedCar.transform.SetParent(newParentObject1.transform);
                    spawnedCar.transform.SetSiblingIndex(3);
                }
                else if(newParentObject1.transform.GetChild(4).gameObject.tag == "PlaceHolder"){
                    Destroy(newParentObject1.transform.GetChild(4).gameObject);
                    spawnedCar.transform.SetParent(newParentObject1.transform);
                    spawnedCar.transform.SetSiblingIndex(4);
                }
                else{
                    spawnedCar.transform.SetParent(newParentObject2.transform);
                }
                spawnedCar.SetActive(false);
                timeToSpawnCounter = timeToSpawn;
                carIsSpawned = 0;
            }
        }

    }

    public void SetSpawnTime(){
        timeToSpawnCounter = Random.Range(minSpawnTime,maxSpawnTime);
    }
}
