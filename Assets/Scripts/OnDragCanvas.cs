using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class OnDragCanvas : MonoBehaviour
{
    public Transform rightHand = null;
    public Transform rightFist = null;
    public GameObject player = null;
    FirstPersonController fpsController = null;

    float step = 0;

    public List<Vector3> MouseMovementList = new List<Vector3>();

    Vector3 rightFistLocalPos = new Vector3(0, 0, 0);
    Vector3 rightHandLocalPos = new Vector3(0, 0, 0);

    public float mouseMovementTimer = 0f;
    public float mouseMovementTime = 2f;
    public bool allowedToAttack = true;
    public bool handReturning = false;
    public bool moveHandToScreen = false;
    public int index = 1;

    // Speed of the attack
    int halfwayPoint = 0;
    int threeOfFourPoint = 0;

    public float speed = 10f;
    float startingSpeed = 0f;
    public float speedIncrease = 0.1f;
    public float SpeedDecrease = 0.4f;
    float decreaseCap = 2f;
    float returnSpeed = 10f;

    public Vector3 weaponAdjustement = new Vector3(-0.4f, -0.3f, 0);
    float ZAxis = 1.5f;

    void Awake()
    {
        //step = startingSpeed * Time.deltaTime;
        rightFistLocalPos = rightFist.localPosition;
        rightHandLocalPos = rightHand.localPosition;
        fpsController = player.GetComponent<FirstPersonController>();
        
    }

    void Update()
    {        
        if (!allowedToAttack && !handReturning)
        {
            // Initialize
            if (moveHandToScreen)
            {
                
                rightHand.localPosition = new Vector3(0.2f, -0.2f, 0f);
                //rightHand.LookAt(MouseMovementList[0]);
                rightHand.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                rightHand.gameObject.SetActive(true);
                moveHandToScreen = false;
                //speed = startingSpeed;
                //halfwayPoint = MouseMovementList.Count / 2;
                //threeOfFourPoint = (MouseMovementList.Count / 4) + halfwayPoint;

                //rightFist.localPosition = new Vector3(MouseMovementList[0].x - 1, MouseMovementList[0].y, ZAxis);
            }

            Vector3 screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 0.7f);
            Vector3 nextPos = Camera.main.ScreenToViewportPoint(screenPoint) + weaponAdjustement;
            //MouseMovementList.Add(Camera.main.ScreenToViewportPoint(screenPoint));

            // Hand Movement
            //Vector3 NextPos = new Vector3(MouseMovementList[index].x - 1, MouseMovementList[index].y, ZAxis);
            step = speed * Time.deltaTime;
            rightFist.localPosition = Vector3.MoveTowards(rightFist.localPosition, nextPos, step);
            //rightFist.localPosition = NextPos;
            rightHand.LookAt(rightFist);

            // Speed
            //if (index <= halfwayPoint)
            //    speed += speedIncrease;

            //else
            //{
            //    if(speed > decreaseCap)
            //    speed -= SpeedDecrease;
            //}


            //if (rightFist.localPosition == NextPos)
            //    index++;

            //if (index >= MouseMovementList.Count)
            //{
            //    handReturning = true;
            //}
        }

        if(handReturning)
            returnrightFist();


    }

    void returnrightFist()
    {
        speed = returnSpeed;
        step = speed * Time.deltaTime;
        rightFist.localPosition = Vector3.MoveTowards(rightFist.localPosition, rightFistLocalPos, step);
        rightHand.localPosition = Vector3.MoveTowards(rightHand.localPosition, rightHandLocalPos, step);
        

        if(rightFist.localPosition == rightFistLocalPos && rightHand.localPosition == rightHandLocalPos)
        {
            rightHand.gameObject.SetActive(false);
            allowedToAttack = true;
            handReturning = false;
            MouseMovementList.Clear();
            mouseMovementTimer = 0f;
            index = 1;
        }
    }

    void OnMouseDown()
    {
        moveHandToScreen = true;
        fpsController.rotationLocked = true;
    }

    void OnMouseDrag()
    {
        if (!allowedToAttack)
            return;

        allowedToAttack = false;
        moveHandToScreen = true;

        //if (mouseMovementTimer >= mouseMovementTime)
        //{
        //    return;
        //}
        //mouseMovementTimer += Time.deltaTime;


    }
    void OnMouseUp()
    {
        handReturning = true;
        allowedToAttack = false;
        fpsController.rotationLocked = false;

        //if (MouseMovementList.Count > 1)
        //{

        //}
    }
}
