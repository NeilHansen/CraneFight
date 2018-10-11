using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public Transform spawn1;
    public Transform spawn2;

    public GameObject puckPrefab;
    private bool Once;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Puck" && this.gameObject.name == "Goal2")
        {
            
            Destroy(other.gameObject);
            //crEATE NEW ONE AT GOAL TWO
            if (Once)
            {
                GameObject clone = Instantiate(puckPrefab, spawn1.position, Quaternion.identity);
                Once = false;
            }

        }
        else if(other.gameObject.tag == "Puck" && this.gameObject.name == "Goal1")
         {
            Destroy(other.gameObject);
            if (Once)
            {
                GameObject clone = Instantiate(puckPrefab, spawn1.position, Quaternion.identity);
                Once = false;
            }
        }
        StartCoroutine(DoOnce());
       // Once = true;
       
    }
    IEnumerator DoOnce()
    {
        yield return new WaitForSeconds(1.0f);
        Once = true;
    }

}
