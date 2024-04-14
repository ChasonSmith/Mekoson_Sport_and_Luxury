using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveController : MonoBehaviour
{
    public Transform player;
    public GameObject ownedCars;
    public GameObject restOfCars;
    public List<GameObject> cars;

    void Start() {
        
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.N)) {
            Load();
        }
    }

    void Save() {
        string path = Application.persistentDataPath + "/test.txt";

        PlayerData playerData = new PlayerData(player);
        InventoryData hotBarData = InventoryData.InventoryDataFactory(ownedCars);
        InventoryData inventoryData = InventoryData.InventoryDataFactory(restOfCars);

        string saveDataJson = JsonUtility.ToJson(new SaveData(playerData, hotBarData, inventoryData));

        File.WriteAllText(path, saveDataJson);
    }

    void Load() {
        string path = Application.persistentDataPath + "/test.txt";
        StreamReader reader = new StreamReader(path);
        string saveDataJson = reader.ReadToEnd();
        SaveData saveData = JsonUtility.FromJson<SaveData>(saveDataJson);

        player.position = saveData.playerData.position;
        player.rotation = saveData.playerData.rotation;

        LoadInventoryData(saveData.hotBarData, ownedCars);
        LoadInventoryData(saveData.inventoryData, restOfCars);
        
        reader.Close();
    }

    void LoadInventoryData(InventoryData inventoryData, GameObject parent) {
        for (int i = 0; i < inventoryData.cars.Count; i++) {
            GameObject child = parent.transform.GetChild(i).gameObject;
            if (child.transform.childCount > 0) {
                Destroy(child.transform.GetChild(0).gameObject);
            }
            foreach (GameObject car in cars) {
                if (inventoryData.cars[i].name == car.name) {
                    GameObject carGameObject= Instantiate(car);
                    carGameObject.transform.parent = child.transform;
                    carGameObject.SetActive(false);
                }
            }
        }
    } 
}

[Serializable]
public class SaveData {
    public PlayerData playerData;
    public InventoryData hotBarData;
    public InventoryData inventoryData;

    public SaveData(PlayerData playerData, InventoryData hotBarData, InventoryData inventoryData) {
        this.playerData = playerData;
        this.hotBarData = hotBarData;
        this.inventoryData = inventoryData;
    }
}

[Serializable]
public class PlayerData {
    public Vector3 position;
    public Quaternion rotation;

    public PlayerData(Vector3 position, Quaternion rotation) {
        this.position = position;
        this.rotation = rotation;
    }
    public PlayerData(Transform transform) {
        this.position = transform.position;
        this.rotation = transform.rotation;
    }
}

[Serializable]
public class InventoryData{
    public List<CarData> cars;

    public InventoryData() {
        cars = new List<CarData>();
    }

    static public InventoryData InventoryDataFactory(GameObject parent) {
        InventoryData inventoryData = new InventoryData();
        for (int i = 0; i < parent.transform.childCount; i++) {
            GameObject child = parent.transform.GetChild(i).gameObject;
            if (child.transform.childCount > 0) {
                string name = child.transform.GetChild(0).gameObject.name.Replace("(Clone)", "");
                inventoryData.Add(new CarData(name));
            } else {
                inventoryData.Add(new CarData("EMPTY"));
            }
        }
        return inventoryData;
    }


    public void Add(CarData carData) {
        cars.Add(carData);
    }



}

[Serializable]
public class CarData {
    public string name;

    public CarData(string name) {
        this.name = name;
    }
}