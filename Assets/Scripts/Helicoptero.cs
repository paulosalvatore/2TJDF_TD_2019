using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicoptero : MonoBehaviour
{
    FollowTarget followTarget;

    public GameObject explosionPrefab;

    public Rigidbody rb;

    public float forcaTorque = 200f;

    void Start()
    {
        followTarget = GetComponent<FollowTarget>();
	}

	void Update()
    {
	}

    void OnTriggerEnter(Collider other)
    {
        //print("trigger enter: " + other.tag);
        if (other.CompareTag("Waypoint"))
        {
            Waypoint waypoint = other.GetComponent<Waypoint>();
            Waypoint waypointPosterior = waypoint.waypointPosterior;
            followTarget.target = waypointPosterior.transform;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //print("collision enter: " + other.gameObject.tag);
        if (other.gameObject.CompareTag("Projétil"))
        {
            //print("É um projétil");

            rb.isKinematic = false;
            rb.useGravity = true;

            Destroy(other.gameObject);

            Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);

            rb.AddTorque(Vector3.right * forcaTorque);
        }
        else if (other.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
        }
    }
}
