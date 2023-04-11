using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearCube : MonoBehaviour
{
    public GameObject deathEffect;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "mop")
        {
            GameObject dE;
            dE = Instantiate(deathEffect, transform.position, transform.rotation);
            GetComponent<Collider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(dE, 0.7f);
            Destroy(this.gameObject, 0.8f);
        }
    }
}
