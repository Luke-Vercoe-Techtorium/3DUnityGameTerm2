using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingArm : MonoBehaviour
{
    [SerializeField]
    private float Speed = 1.0f;

    private Rigidbody rb = null;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        rb.MoveRotation(Quaternion.AngleAxis(Speed * Time.time, Vector3.forward));
    }
}
