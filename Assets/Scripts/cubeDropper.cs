using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeDropper : MonoBehaviour
{
    public buttonScript inputScript;
    bool prevValue = false;
    public GameObject cubePref, deathEffect;
    public List<GameObject> cubes = new List<GameObject>();
    private void Update()
    {
        if(inputScript.value != prevValue)
        {
            prevValue = inputScript.value;
            if (prevValue)
            {
                GameObject gO;
                gO = Instantiate(cubePref, transform.position, transform.rotation);
                cubes.Add(gO);
            }
        }
    }
}
