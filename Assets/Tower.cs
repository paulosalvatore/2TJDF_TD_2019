using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public GameObject projetilPrefab;
    public Transform spawnPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(
                projetilPrefab,
                spawnPoint.position,
                projetilPrefab.transform.rotation
            );
        }
	}
}
