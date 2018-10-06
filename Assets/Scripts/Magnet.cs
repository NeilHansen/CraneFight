using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour {



    public bool hasCar = false;
    public Transform car;
     Rigidbody myBody;
	// Use this for initialization
	void Start () {
       myBody = this.GetComponent<Rigidbody>();
	}

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Collided");

        if (Input.GetKeyDown(KeyCode.Space) && !hasCar)
        {
            Debug.Log("Activated magnet");
            if (other.gameObject.tag == "Car")
            {
                Debug.Log("Car Pick Up");
                other.gameObject.transform.parent = this.gameObject.transform;
                car = other.gameObject.transform;
                hasCar = true;
            }
        }
        
       
    }

    void Update()
    {
        if (hasCar && Input.GetKeyDown(KeyCode.A))
        {

            if (car != null)
            {

                
                //Debug.Log(other.gameObject.transform.parent);
                Debug.Log("Release");
                car.gameObject.transform.parent = null;
                car.GetComponent<Rigidbody>().velocity = myBody.velocity;
                hasCar = false;
            }
        }
    }
}
