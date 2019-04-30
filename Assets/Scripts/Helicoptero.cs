using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicoptero : MonoBehaviour
{
    FollowTarget followTarget;

	void Start()
    {
        followTarget = GetComponent<FollowTarget>();
	}

	void Update()
    {
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Waypoint"))
        {
            Waypoint waypoint = other.GetComponent<Waypoint>();
            Waypoint waypointPosterior = waypoint.waypointPosterior;
            followTarget.target = waypointPosterior.transform;
        }
    }
}
