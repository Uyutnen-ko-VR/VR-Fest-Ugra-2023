using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poddon : MonoBehaviour
{
    public float mass;
    
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Finish":
                print("Finish");
                FindObjectOfType<Grabber>().GetComponent<Collider>().isTrigger = true;
                Invoke(nameof(ReturnAbility), 10f);
                Destroy(this);
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Kleshny" && other.transform.parent.parent.parent.GetComponent<forkScript>())
        {
            print(other.transform.parent.parent.parent.GetComponent<forkScript>().maxMass - mass);
            if (other.transform.parent.parent.parent.GetComponent<forkScript>().maxMass < mass)
            {
                other.transform.parent.parent.parent.GetComponent<forkScript>().Brake();
            }
        }
    }


    private void ReturnAbility()
    {
        FindObjectOfType<Grabber>().GetComponent<Collider>().isTrigger = false;
    }
}
