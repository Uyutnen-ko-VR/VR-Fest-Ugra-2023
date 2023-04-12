using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getQuaternionScript : MonoBehaviour
{
    public Quaternion output;
    public Transform doll;
    void Update()
    {
        output = doll.localRotation;
        if (output.x < 0.001f)
            output.x = 0;
        if (output.y < 0.001f)
            output.y = 0;
        if (output.z < 0.001f)
            output.z = 0;
    }
}
