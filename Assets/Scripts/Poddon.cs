using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poddon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Finish":
                print("Finish");
                FindObjectOfType<Grabber>().GetComponent<Collider>().isTrigger = true;
                Invoke(nameof(ReturnAbility), 10f);
                break;
        }
    }

    private void ReturnAbility()
    {
        FindObjectOfType<Grabber>().GetComponent<Collider>().isTrigger = false;
    }
}
