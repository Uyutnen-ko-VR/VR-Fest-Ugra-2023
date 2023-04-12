using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPositionScript : MonoBehaviour
{
    public Transform doll, target;
    void Update()
    {
        doll.position = target.position;
        doll.Rotate(0, target.rotation.y - doll.rotation.y, 0);
    }
}
