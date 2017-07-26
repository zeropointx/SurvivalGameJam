using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {
    NavMeshAgent navMeshAgent = null;
	// Use this for initialization
	void Start ()
    {
        navMeshAgent = transform.GetComponent<NavMeshAgent>();
	}
	Vector3 getTarget()
    {
       var player =  GameObject.FindGameObjectWithTag("Player");
        return player.transform.position;
    }
	// Update is called once per frame
	void Update ()
    {
        navMeshAgent.SetDestination(getTarget());
	}
}
