using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public int boundary = 3;
    public int speed = 5;

    int theScreenWidth;
    int theScreenHeight; 
    

	void Start () {
        Cursor.lockState = CursorLockMode.Confined;
        theScreenWidth = Screen.width;
        theScreenHeight = Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
        SlideCamera();
        ZoomCamera();
    }

    void SlideCamera()
    {
        if (Input.mousePosition.x > theScreenWidth - boundary)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.mousePosition.x < 0 + boundary)
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        if (Input.mousePosition.y > theScreenHeight - boundary)
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Input.mousePosition.y < 0 + boundary)
            transform.Translate(-Vector3.up * speed * Time.deltaTime);
    }
    void ZoomCamera()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.fieldOfView > 10)
            Camera.main.fieldOfView -= 2;
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.fieldOfView < 130)
            Camera.main.fieldOfView += 2;
    }
}
