using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    GameObject arrow;
    Rigidbody rigidbody;
    void Start() {
        arrow = GameObject.Find("Speedometer");
        rigidbody = GetComponent<Rigidbody>();
        Debug.Log(transform.gameObject.name);
    }

    void Update() {
        arrow.transform.rotation = Quaternion.Euler(0, 0, -rigidbody.velocity.magnitude);
    }
}
