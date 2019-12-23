using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestShit : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print(Resources.FindObjectsOfTypeAll(typeof(Material)).Length);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
            transform.GetComponent<Renderer>().material = Resources.Load("Green") as Material;
	}
}
