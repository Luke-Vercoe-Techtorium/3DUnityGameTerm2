using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    [SerializeField]
    private Rigidbody PistonArm = null;
    [SerializeField]
    private float MoveDistance = 3.0f;
    [SerializeField]
    private float Offset = 0.0f;
    [SerializeField]
    private float Speed = 1.0f;

    public void FixedUpdate()
    {
        float value = Mathf.Sin(Time.fixedTime * Speed + Offset);
        PistonArm.MovePosition(transform.position + new Vector3(value * MoveDistance, 0.0f, 0.0f));
    }
}
