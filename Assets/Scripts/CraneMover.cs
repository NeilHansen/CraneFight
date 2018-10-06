using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneMover : MonoBehaviour {

    private Rigidbody myBody;
    public float force;
	// Use this for initialization
	void Start () {
       myBody =  this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        myBody.velocity = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //this.transform.position += new Vector3(0,0,10) * Time.deltaTime;
            myBody.velocity = new Vector3(0, 0, 0);
            myBody.AddForce(new Vector3(0, 0, 1) * force);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            myBody.velocity = new Vector3(0, 0, 0);
            myBody.AddForce(new Vector3(0, 0, -1) * force);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            myBody.velocity = new Vector3(0, 0, 0);
            myBody.AddForce(new Vector3(1, 0, 0) * force);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myBody.velocity = new Vector3(0, 0, 0);
            myBody.AddForce(new Vector3(-1, 0, 0) * force);
        }

      
    }
}
