using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadController : MonoBehaviour {
    public TMP_Dropdown dropdown;
    void Start() {
        
    }

    void Update() {
        
    }

    public void LoadWorld() {
        GlobalVariables.Set("level", "chicken");
        SceneManager.LoadScene("SampleScene");
    }
}
