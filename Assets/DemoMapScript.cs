using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoMapScript : MonoBehaviour {

    public List<GameObject> forestSpots = new List<GameObject>();
    public List<GameObject> lakeSpots = new List<GameObject>();
    public List<GameObject> crossroadsSpots = new List<GameObject>();
    public List<GameObject> townSpots = new List<GameObject>();
    public List<GameObject> mountainSpots = new List<GameObject>();
    public List<GameObject> caveSpots = new List<GameObject>();

    public GameManager gameManager;

	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckSpots();
	}

    void CheckSpots()
    {
        foreach (PlayerScript player in gameManager.players)
            print(player.characterScript.currentSpot);
    }
}
