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

	// Use this for initialization
	void Start () {
       myBody = this.GetComponent<Rigidbody>();
        playerController = ReInput.players.GetPlayer(playerId);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Collided");

        if (Input.GetKeyDown(KeyCode.Space) && !hasCar || playerController.GetButtonDown("PickUp") && !hasCar)
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
        if (hasCar && Input.GetKeyDown(KeyCode.A) || playerController.GetButtonDown("Drop") && hasCar)
        {

            if (car != null)
            {

                //Debug.Log(other.gameObject.transform.parent);
                Debug.Log("Release");
                car.gameObject.transform.parent = null;
                car.GetComponent<Rigidbody>().velocity = myBody.velocity * multiplier;
                hasCar = false;
            }
        }
    }
}
