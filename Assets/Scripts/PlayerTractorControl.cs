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
            // gameObject.layer = LayerMask.NameToLayer("Tractor");
            gameObject.GetComponent<Collider>().enabled = false;
            transform.SetParent(other.transform.parent, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TractorTrigger"))
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
            gameObject.GetComponent<Collider>().enabled = true;
            transform.SetParent(other.transform.parent.parent, true);
        }
    }
}
