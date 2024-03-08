using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGlobal : MonoBehaviour
{
    public Image[] globalInventory;
    public GameObject[] inventory;
    public Image image;
    void Start()
    {
        
    }

    void Update()
    {
        for (int i = 0; i < 5; i++) {
            globalInventory[i].sprite = inventory[i].transform.GetChild(0).GetComponent<Image>().sprite;
        }
    }
}
