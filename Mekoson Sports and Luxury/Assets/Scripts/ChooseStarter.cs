using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseStarter : MonoBehaviour
{
    public InsatiateCar instCar;
    public GameObject ChoicePanel;
    // Start is called before the first frame update
    void Start()
    {
        instCar = GameObject.FindGameObjectWithTag("Needed").GetComponent<InsatiateCar>();
    }

    public void SportStart(){
        instCar.spawnCar(1);
        ChoicePanel.SetActive(false);
    }

    public void LuxuryStart(){
        instCar.spawnCar(2);
        ChoicePanel.SetActive(false);
    }
}
