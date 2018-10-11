using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour {

    private Rigidbody mybody;
    public float multiplier;
    // Use this for initialization
    void Start () {
       mybody =  this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Car")
        {
            Debug.Log("hit Puck");

            mybody.AddForce((mybody.position - collision.contacts[0].point) * multiplier, ForceMode.Impulse);
           
        }
    }
}
