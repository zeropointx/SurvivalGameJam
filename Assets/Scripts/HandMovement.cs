using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour {

    public GameObject leftHand = null;
    public GameObject rightHand = null;
    public GameObject playerModel = null;

    private Vector3 clickStartCoordinate;
    private Vector3 clickEndCoordinate;


    private bool mouseDown = false;

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
            clickStartCoordinate = GetMousePosition();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }

        if (mouseDown)
            FistMovement(clickStartCoordinate);
       
	}

    void FistMovement(Vector3 clickStart)
    {

    }

    Vector3 GetMousePosition()
    {
        return Input.mousePosition;
        
    }
}
