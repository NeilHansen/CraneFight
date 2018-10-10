using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class CraneMover : MonoBehaviour {

    public int playerId = 0;

    private Rigidbody myBody;
    public float force;

    private Rewired.Player playerController;

	// Use this for initialization
	void Start () {
       myBody =  this.GetComponent<Rigidbody>();
        playerController = ReInput.players.GetPlayer(playerId);
	}
	
	// Update is called once per frame
	void Update () {
        myBody.velocity = new Vector3(0, 0, 0);
        if (playerController.GetAxis("Move Vertical") != 0.0f)
            {
            if (Input.GetKey(KeyCode.UpArrow) || playerController.GetAxis("Move Vertical") >= 0.0f)
            {
                Debug.Log("moving");
                //this.transform.position += new Vector3(0,0,10) * Time.deltaTime;
                myBody.velocity = new Vector3(0, 0, 0);
                myBody.AddForce(new Vector3(0, 0, 1) * force);
            }

            if (Input.GetKey(KeyCode.DownArrow) || playerController.GetAxis("Move Vertical") <= 0.0f)
            {
                myBody.velocity = new Vector3(0, 0, 0);
                myBody.AddForce(new Vector3(0, 0, -1) * force);
            }
        }
        if (playerController.GetAxis("Move Horizontal") != 0.0f)
        {
            if (Input.GetKey(KeyCode.RightArrow) || playerController.GetAxis("Move Horizontal") >= 0.0f)
            {
                myBody.velocity = new Vector3(0, 0, 0);
                myBody.AddForce(new Vector3(1, 0, 0) * force);
            }

            if (Input.GetKey(KeyCode.LeftArrow) || playerController.GetAxis("Move Horizontal") <= 0.0f)
            {
                myBody.velocity = new Vector3(0, 0, 0);
                myBody.AddForce(new Vector3(-1, 0, 0) * force);
            }
        }
      
    }
}
