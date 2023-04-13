using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GruzManager : MonoBehaviour
{
    public float allKilos, completedKilos;
    public TextMeshProUGUI remainKilosText, completedKilosText;
    
    void Start()
    {
        UpdateTexts();
    }

    public void UpdateTexts()
    {
        remainKilosText.SetText($"{allKilos - completedKilos} кг");
        completedKilosText.SetText($"{completedKilos} кг");

        if (allKilos == completedKilos)
        {
            print("Yra");
        }
    }
}
