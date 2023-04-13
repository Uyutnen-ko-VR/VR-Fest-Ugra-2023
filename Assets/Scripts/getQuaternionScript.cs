using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getQuaternionScript : MonoBehaviour
{
    public Quaternion output;
    public float outputAngle;
    public Transform doll;

    private HingeJoint _joint;

    private void Start()
    {
        _joint = GetComponent<HingeJoint>();
    }

    void Update()
    {
        outputAngle = _joint.angle;
        output = doll.localRotation;
        if (output.x < 0.001f)
            output.x = 0;
        if (output.y < 0.001f)
            output.y = 0;
        if (output.z < 0.001f)
            output.z = 0;
    }
}
