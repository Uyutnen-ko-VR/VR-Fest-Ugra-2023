using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Poddon : MonoBehaviour
{
    public TextMeshProUGUI massText, maxMassText;
    
    private float _mass;
    private bool _isChecked;

    private void Awake()
    {
        maxMassText.SetText($"{FindObjectOfType<forkScript>().maxMass} кг");
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Finish":
                var man = FindObjectOfType<GruzManager>();

                man.completedKilos += _mass;
                man.UpdateTexts();
                
                print("Finish");
                FindObjectOfType<Grabber>().GetComponent<Collider>().isTrigger = true;
                Invoke(nameof(ReturnAbility), 10f);
                Destroy(this);
                break;
            
            case "Kleshny":
                if (_isChecked) return;

                massText.transform.parent.gameObject.SetActive(false);
                
                _isChecked = true;
                
                if (other.transform.parent.parent.parent.GetComponent<forkScript>())
                {
                    if (other.transform.parent.parent.parent.GetComponent<forkScript>().maxMass < _mass)
                    {
                        other.transform.parent.parent.parent.GetComponent<forkScript>().Brake();
                    }
                }
                break;
        }
    }

    public void ChangeMass(float newMass)
    {
        _mass += newMass;
        massText.SetText($"{Mathf.Round(_mass)} кг");
    }


    private void ReturnAbility()
    {
        FindObjectOfType<Grabber>().GetComponent<Collider>().isTrigger = false;
    }
}
