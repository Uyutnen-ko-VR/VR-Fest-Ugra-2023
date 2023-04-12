using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPositionScript : MonoBehaviour
{
    public Transform doll, target;
    private void Start()
    {
        if (doll == null)
            doll = this.transform;
    }

    void Update()
    {
        doll.position = target.position;
        doll.Rotate(0, target.rotation.y - doll.rotation.y, 0);
    }
}
