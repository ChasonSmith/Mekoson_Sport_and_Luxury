using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveController : MonoBehaviour
{
    public Transform player;
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
        string playerJson = JsonUtility.ToJson(new PlayerData(player));
        File.WriteAllText(path, playerJson);
    }

    void Load() {
        string path = Application.persistentDataPath + "/test.txt";
        StreamReader reader = new StreamReader(path);
        string playerJson = reader.ReadToEnd();
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(playerJson);
        player.position = playerData.position;
        player.rotation = playerData.rotation;
        reader.Close();
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