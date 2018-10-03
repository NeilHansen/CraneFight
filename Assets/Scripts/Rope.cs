using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

    internal Rigidbody mybody;
     
	internal void Start () {
        this.gameObject.AddComponent<Rigidbody>();
        this.mybody = this.gameObject.GetComponent<Rigidbody>();
        this.mybody.isKinematic = true;

        int childcount = this.transform.childCount;

        for(int i = 0; i < childcount; i++)
        {
            Transform trans = this.transform.GetChild(i);

            trans.gameObject.AddComponent<HingeJoint>();

            HingeJoint hinge = trans.gameObject.GetComponent<HingeJoint>();

            hinge.connectedBody =
                i == 0 ? this.mybody :
                this.transform.GetChild(i - 1).GetComponent<Rigidbody>();

            hinge.useSpring = true;
            hinge.enableCollision = true;
        
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
