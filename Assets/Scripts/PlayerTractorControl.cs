using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTractorControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TractorTrigger"))
        {
            print("Smth");
            gameObject.layer = LayerMask.NameToLayer("Tractor");
            transform.SetParent(other.transform.parent, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TractorTrigger"))
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
            transform.SetParent(other.transform.parent.parent, true);
        }
    }
}
