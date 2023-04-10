using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getWeight : MonoBehaviour
{
    public float weight = 15f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "gruz")
            weight += other.gameObject.GetComponent<Rigidbody>().mass;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "gruz")
            weight -= other.gameObject.GetComponent<Rigidbody>().mass;
    }
}
