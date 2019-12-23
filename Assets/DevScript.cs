using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevScript : MonoBehaviour
{
    public void SlideButtons(GameObject buttonMenu)
    {
        print(buttonMenu.transform.position.y);
        if (buttonMenu.transform.position.y == 837)
            transform.position = new Vector3(transform.position.x, 521.43f, transform.position.z);
        if (buttonMenu.transform.position.y == 521.43f)
            transform.position = new Vector3(transform.position.x, 837, transform.position.z);
    }
}
