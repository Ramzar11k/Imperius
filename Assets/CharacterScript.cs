using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

    public GameObject currentSpot;
	void Start () {
        GetCurrentSpot();	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void GetCurrentSpot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position - new Vector3(0, 1.5f, 0), Vector3.down, out hit, 2))
        {
            currentSpot = hit.transform.gameObject;
        }
    }
}
