using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour {
    public float MinAngle = 0;
    public float MaxAngle = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //clamp magnet
        Quaternion currentRot = transform.rotation;

        currentRot.x = Mathf.Clamp(currentRot.x, MinAngle, MaxAngle);
        transform.rotation = currentRot;
    }
}
