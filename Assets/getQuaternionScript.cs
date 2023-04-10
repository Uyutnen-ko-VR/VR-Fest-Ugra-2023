using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getQuaternionScript : MonoBehaviour
{
    public Quaternion output;
    public Transform doll;
    void Update()
    {
        output = doll.rotation;
    }
}
