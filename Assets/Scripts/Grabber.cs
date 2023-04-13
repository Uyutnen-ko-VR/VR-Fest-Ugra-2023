using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    // private GameObject _box;
    // private void OnTriggerEnter(Collider other)
    // {
    //     switch (other.tag)
    //     {
    //         case "Poddon":
    //             print("Poddon");
    //             _box = other.gameObject;
    //             other.isTrigger = true;
    //             GetComponent<Collider>().isTrigger = false;
    //             break;
    //         case "Finish":
    //             print("Finish");
    //             GetComponent<Collider>().isTrigger = true;
    //             _box.GetComponent<Collider>().isTrigger = false;
    //             _box.transform.parent.position = other.transform.position;
    //             Destroy(_box.transform.parent.GetComponent<Rigidbody>());
    //             break;
    //     }
    // }
    //
    // private void OnCollisionEnter(Collision other)
    // {
    //     switch (other.gameObject.tag)
    //     {
    //         case "Finish":
    //             print("Finish");
    //             GetComponent<Collider>().isTrigger = true;
    //             _box.GetComponent<Collider>().isTrigger = false;
    //             _box.transform.parent.position = other.transform.position;
    //             Destroy(_box.transform.parent.GetComponent<Rigidbody>());
    //             break;
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.tag == "Poddon")
    //     {
    //         print("End");
    //     }
    // }
}
