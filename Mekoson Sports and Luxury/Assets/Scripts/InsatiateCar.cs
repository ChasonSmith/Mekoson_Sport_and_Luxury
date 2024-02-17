using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsatiateCar : MonoBehaviour
{
    public GameObject Charger;
    public GameObject CorvetteC8;
    public Transform parent;
    public void spawnCar(int CarNum){
        if(CarNum == 1){
            //Instantiate(Charger, new Vector3(0,1,10), Quaternion.identity);
            GameObject newObj = Instantiate(Charger,parent);
            newObj.SetActive(false);
        }
        else if(CarNum == 2){
            //Instantiate(CorvetteC8, new Vector3(0,1,10), Quaternion.identity);
            GameObject newObj = Instantiate(CorvetteC8,parent);
            newObj.SetActive(false);
        }
        
    }
}
