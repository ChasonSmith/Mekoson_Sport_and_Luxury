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
                    spawnedCar.tag = "AiCar";
                    carIsSpawned = 1;
                }
                else if(carIsSpawned == 1){
                    Destroy(spawnedCar);
                    carIsSpawned = 0;
                }
            }
        }

    }

    public void SetSpawnTime(){
        timeToSpawnCounter = Random.Range(minSpawnTime,maxSpawnTime);
    }
}
