using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDragCanvas : MonoBehaviour
{
    public Transform rightHand = null;
    public Transform rightFist = null;
    
    public float speed = 10;
    float step = 0;

    public List<Vector3> MouseMovementList = new List<Vector3>();

    Vector3 rightFistLocalPos = new Vector3(0, 0, 0);
    Vector3 rightHandLocalPos = new Vector3(0, 0, 0);

    public float mouseMovementTimer = 0f;
    public float mouseMovementTime = 2f;
    public bool allowedToAttack = true;
    public bool handReturning = false;
    public bool moveHandToScreen = false;
    public int index = 0;

    void Awake()
    {
        step = speed * Time.deltaTime;
        rightFistLocalPos = rightFist.localPosition;
        rightHandLocalPos = rightHand.localPosition;
    }

    void Update()
    {        
        if (!allowedToAttack && !handReturning)
        {
            if (moveHandToScreen)
            {
                rightHand.localPosition = new Vector3(0.5f, -0.2f, 0f);
                moveHandToScreen = false;
            }

            Vector3 NextPos = new Vector3(MouseMovementList[index].x - 1, MouseMovementList[index].y + 0.5f, 1);
            rightFist.localPosition = NextPos;
            rightHand.LookAt(rightFist);
            index++;

            if (index >= MouseMovementList.Count)
            {
                handReturning = true;
            }
        }
        else if(handReturning)
            returnrightFist();


    }

    void returnrightFist()
    {
        rightFist.localPosition = Vector3.MoveTowards(rightFist.localPosition, rightFistLocalPos, step);
        rightHand.localPosition = Vector3.MoveTowards(rightHand.localPosition, rightHandLocalPos, step);
        rightHand.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        if(rightFist.localPosition == rightFistLocalPos && rightHand.localPosition == rightHandLocalPos)
        {
            allowedToAttack = true;
            handReturning = false;
            MouseMovementList.Clear();
            mouseMovementTimer = 0f;
            index = 1;
        }
    }

    void OnMouseDrag()
    {
        if (!allowedToAttack)
            return;

        if (mouseMovementTimer >= mouseMovementTime)
        {
            allowedToAttack = false;
            moveHandToScreen = true;
            return;
        }

        Vector3 screenPoint = new Vector3(Input.mousePosition.x * 2, Input.mousePosition.y - 1, Input.mousePosition.z);
        MouseMovementList.Add(Camera.main.ScreenToViewportPoint(screenPoint));
        mouseMovementTimer += Time.deltaTime;


    }
/*
    IEnumerator Attack()
    {
        while (true)
        {
            for (int i = 0; i < MouseMovementList.Count; i++)
            {
                while (true)
                {
                    Vector3.MoveTowards(rightFist.localPosition, MouseMovementList[i], step);

                    if (rightFist.localPosition == MouseMovementList[i])
                        break;
                }
            }

            MouseMovementList.Clear();
            allowedToAttack = true;
            yield break;
        }
    }
 */   
    void OnMouseUp()
    {
        if (MouseMovementList.Count >= 0)
        {
            allowedToAttack = false;
            moveHandToScreen = true;
        }
    }

    /*void ReturnFist()
    {
        float step = returnSpeed * Time.deltaTime;
        fist.localPosition = Vector3.MoveTowards(fist.localPosition, fist.GetComponent<HandMovement>().localPos, step);

        if(fist.localPosition == fist.GetComponent<HandMovement>().localPos)
            returning = false;
    }*/
}
