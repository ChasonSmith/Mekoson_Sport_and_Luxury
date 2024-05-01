using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;
        
public class LoadController : MonoBehaviour {
    public TMP_Dropdown dropdown;
    public GameObject starter;
    public List<GameObject> world;
    public SaveController saveController;
    public GameObject startCam;

    void Start() {
        updateDropdown();
    }

    void updateDropdown() {
        dropdown.ClearOptions();
        IEnumerable<string> myFiles = Directory.EnumerateFiles(Application.persistentDataPath, "*.msf", SearchOption.AllDirectories);
        List<string> pathList = new List<string>(myFiles);
        List<string> nameList = new List<string>(); 
        foreach (string path in pathList) {
            nameList.Add(Path.GetFileNameWithoutExtension(path));
        }
        dropdown.AddOptions(nameList);
    }

    public void NewWorld() {
        this.gameObject.SetActive(false);
        startCam.SetActive(false);
        starter.SetActive(true);
        TurnWorldOn();
    }

    public void LoadWorld() {
        saveController.Load(dropdown.options[dropdown.value].text);
        this.gameObject.SetActive(false);
        TurnWorldOn();
    }

    public void TurnWorldOn() {
        foreach (GameObject thing in world) {
            thing.SetActive(true);
        }
    }
}
