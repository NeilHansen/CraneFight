using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Magnet : MonoBehaviour {

    public int playerId;

    private Rewired.Player playerController;

    public bool hasCar = false;
    public Transform car;

    public float multiplier;
     Rigidbody myBody;
    Collider myCollider;

	// Use this for initialization
	void Start () {
       myBody = this.GetComponent<Rigidbody>();
        playerController = ReInput.players.GetPlayer(playerId);
        myCollider = this.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");

        if(!hasCar)
        {
            Debug.Log("Activated magnet");
            if (other.gameObject.tag == "Car")
            {
                Debug.Log("Car Pick Up");
                car = other.gameObject.transform;

                //other.gameObject.transform.parent = this.gameObject.transform.GetChild(0).transform;
                car.position = this.gameObject.transform.GetChild(0).transform.position;
                car.rotation = this.gameObject.transform.GetChild(0).transform.rotation;
                car.GetComponent<Rigidbody>().isKinematic = true;
                car.gameObject.transform.parent = this.gameObject.transform.GetChild(0).transform;
               // car.localPosition = Vector3.zero;
               // car.gameObject.transform.parent = this.gameObject.transform.GetChild(0).transform;

                hasCar = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !hasCar || playerController.GetButtonDown("PickUp") && !hasCar)
        {
            Debug.Log("Activated magnet");
            if (other.gameObject.tag == "Car")
            {
                Debug.Log("Car Pick Up");
               
                car = other.gameObject.transform.GetChild(0).transform;
                other.gameObject.transform.parent = this.gameObject.transform.GetChild(0).transform;
              
                hasCar = true;
            }
        }
        
       
    }

    void Update()
    {
        if (hasCar && Input.GetKeyDown(KeyCode.A) || playerController.GetButtonDown("Drop") && hasCar)
        {

            if (car != null)
            {
                //Debug.Log(other.gameObject.transform.parent);
                Debug.Log("Release");
                car.GetComponent<Rigidbody>().isKinematic = false;
                car.gameObject.transform.parent = null;
                car.GetComponent<Rigidbody>().velocity = myBody.velocity * multiplier;
                myCollider.enabled = false;
                hasCar = false;
               
            }
        }
    }
}
