﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour {

    public GameObject belt;
    public Transform endpoint;
    public float speed;

    void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
