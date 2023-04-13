using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poddon : MonoBehaviour
{
    public float mass;
    private bool _isChecked;
    
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Finish":
                var man = FindObjectOfType<GruzManager>();

                man.completedKilos += mass;
                man.UpdateTexts();
                
                print("Finish");
                FindObjectOfType<Grabber>().GetComponent<Collider>().isTrigger = true;
                Invoke(nameof(ReturnAbility), 10f);
                Destroy(this);
                break;
            
            case "Kleshny":
                if (_isChecked) return;

                _isChecked = true;
                
                if (other.transform.parent.parent.parent.GetComponent<forkScript>())
                {
                    if (other.transform.parent.parent.parent.GetComponent<forkScript>().maxMass < mass)
                    {
                        other.transform.parent.parent.parent.GetComponent<forkScript>().Brake();
                    }
                }
                break;
        }
    }


    private void ReturnAbility()
    {
        FindObjectOfType<Grabber>().GetComponent<Collider>().isTrigger = false;
    }
}
