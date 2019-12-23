using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyScript : MonoBehaviour {

    public int actions = 1;
    public GameObject currentSpot;
    public Transform targetSpot;

    public List<GameObject> platformPath = new List<GameObject>();
    public List<GameObject> platforms = new List<GameObject>();
    public List<GameObject> analyzedSpots = new List<GameObject>();
    public List<int> costs = new List<int>();

    public int movementSpeed;
    float distanceTraveled = 0;
    public bool moving;

    float delayTime = 0.2f;


    void Start () {
        targetSpot.GetComponent<Renderer>().material.color = Color.red;
        GetCurrentSpot();
        movementSpeed = transform.GetComponent<RenderCard>().thisCard.cardMovement;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.DrawRay(transform.position - new Vector3(0, 1.5f, 0), Vector3.down * 2, Color.green);
        if (moving == true && platformPath.Count != 0)
            Movement();
        if (Input.GetKeyDown(KeyCode.P))
            StartCoroutine(ComputePath());
        if (movementSpeed <= 0 || currentSpot == targetSpot)
        {
            moving = false;
        }
    }

    void Movement()
    {
        if (Vector3.Distance(transform.position, platformPath[0].transform.position + new Vector3(0, 2.5f, 0)) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, platformPath[0].transform.position + new Vector3(0,2.5f,0), distanceTraveled);
            distanceTraveled += Time.deltaTime * 0.5f;
            return;
        }
        distanceTraveled = 0;
        transform.position = platformPath[0].transform.position + new Vector3(0, 2.5f, 0);
        platformPath.RemoveAt(0);
        GetCurrentSpot();
    }
    void GetCurrentSpot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position - new Vector3(0, 1.5f, 0), Vector3.down, out hit, 2))
        {
            currentSpot = hit.transform.gameObject;
        }
    }
    IEnumerator ComputePath()
    {
        if (platforms.Count == 0)
        {
            platforms.Add(currentSpot);
            costs.Add(0);
        }
        platformPath.Clear();
        var currentPlatform = currentSpot;
        while (platforms.Contains(targetSpot.gameObject) == false)
        {
            currentPlatform.transform.GetComponent<Renderer>().material.color = Color.green;
            for (var i =0; i < currentPlatform.GetComponent<SpotScript>().connectedSpots.Count; i++)
            {
                if (!platforms.Contains(currentPlatform.GetComponent<SpotScript>().connectedSpots[i]) && !analyzedSpots.Contains(currentPlatform.GetComponent<SpotScript>().connectedSpots[i]))
                {
                    currentPlatform.GetComponent<SpotScript>().connectedSpots[i].GetComponent<SpotScript>().spotThatFetchedThis = currentPlatform;
                    platforms.Add(currentPlatform.GetComponent<SpotScript>().connectedSpots[i]);
                    costs.Add(costs[platforms.IndexOf(currentPlatform)] + 1);
                }
            }
            yield return new WaitForSeconds(delayTime);
            currentPlatform.transform.GetComponent<Renderer>().material.color = Color.white;
            analyzedSpots.Add(currentPlatform);
            int currentIndex = platforms.IndexOf(currentPlatform);
            platforms.RemoveAt(currentIndex);
            costs.RemoveAt(currentIndex);
            currentIndex = costs.IndexOf(costs.Min());
            currentPlatform = platforms[currentIndex];
        }
        currentPlatform = targetSpot.gameObject;
        platformPath.Add(currentPlatform);
        while (currentPlatform != currentSpot)
        {
            currentPlatform.transform.GetComponent<Renderer>().material.color = Color.green;
            yield return new WaitForSeconds(delayTime);
            currentPlatform.transform.GetComponent<Renderer>().material.color = Color.white;
            currentPlatform = currentPlatform.GetComponent<SpotScript>().spotThatFetchedThis;
            platformPath.Add(currentPlatform);
        }
        platformPath.Reverse();
        platformPath.RemoveAt(0);
        platforms.Clear();
        analyzedSpots.Clear();
        costs.Clear();
        moving = true;
        yield return null;
    }
}
