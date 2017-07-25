using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class HandMovement : MonoBehaviour
{
    public Vector3 localPos = new Vector3(0, 0, 0);

    void Awake()
    {
        localPos = transform.localPosition;
    }

}