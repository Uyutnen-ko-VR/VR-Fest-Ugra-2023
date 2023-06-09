﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassAdder : MonoBehaviour
{
    private Poddon _poddon;

    private void Start()
    {
        _poddon = transform.parent.GetComponent<Poddon>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<Rigidbody>()) return;

        // print("OK");
        _poddon.ChangeMass(other.GetComponent<Rigidbody>().mass);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<Rigidbody>()) return;

        _poddon.ChangeMass(-other.GetComponent<Rigidbody>().mass);
    }
}
