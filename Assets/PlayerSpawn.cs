using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour {
    public GameObject playerPrefab = null;
	void Start ()
    {
        GameObject.Instantiate(playerPrefab, transform);
    }
    void Update ()
    {
		
	}
}
