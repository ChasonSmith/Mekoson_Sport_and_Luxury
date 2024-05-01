using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCam : MonoBehaviour
{
    public Camera activeCamera;
    public Camera[] allCameras;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get all cameras in the scene
        allCameras = Camera.allCameras;

        // Find the active camera
        activeCamera = null;
        foreach (Camera cam in allCameras)
        {
            if (cam.gameObject.activeInHierarchy)
            {
                activeCamera = cam;
                break;
            }
        }

        // Set the render camera of the canvas to the active camera
        Canvas canvas = GetComponent<Canvas>();
        if (canvas != null && activeCamera != null)
        {
            //canvas.renderMode = RenderMode.WorldSpace; // Set render mode if not already set
            canvas.worldCamera = activeCamera;
            canvas.planeDistance = 1f;
        }
        else
        {
            Debug.LogWarning("Canvas or active camera not found.");
        }
    }
}
