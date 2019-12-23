using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotScript : MonoBehaviour {

    public List<GameObject> connectedSpots;
    public GameObject spotThatFetchedThis;

	void Start () {
        GetNeighbours();
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    void GetNeighbours()
    {
        connectedSpots.Clear();
        foreach (Transform target in transform.GetChild(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.GetChild(0).position, GetDirection(target), out hit, 15))
            {
                connectedSpots.Add(hit.transform.gameObject);
            }
        }
        
    }

    Vector3 GetDirection(Transform target)
    {
        Vector3 pos = target.position - transform.position;
        Vector3 dir = pos.normalized;
        return dir;
    }
}
