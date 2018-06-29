using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour {

    public GameObject ObjToSpawn;
    public float GapTime = 1;

	// Use this for initialization
	void Start () {

        InvokeRepeating("SpawnObj", 0, GapTime);
		
	}
	
	void SpawnObj() {

        Instantiate(ObjToSpawn);
		
	}
}
