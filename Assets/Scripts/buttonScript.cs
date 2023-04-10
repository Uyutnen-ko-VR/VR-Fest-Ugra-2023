using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public bool resetValueWhenReleased = true, value = false;
    public int interactions = 0;
    public Material onMat, offMat;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Interactor")
        {
            interactions += 1;
            if (interactions == 1)
            {
                if (resetValueWhenReleased || !value)
                {
                    this.GetComponent<MeshRenderer>().material = onMat;
                    value = true;
                }
                else
                {
                    this.GetComponent<MeshRenderer>().material = offMat;
                    value = false;
                }
            }
            else
                print("Already interacted");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactor")
        {
            interactions -= 1;
            if (interactions == 0)
            {
                if (resetValueWhenReleased)
                {
                    this.GetComponent<MeshRenderer>().material = offMat;
                    value = false;
                }
            }
            else
                print("Ii");
        }
    }
}
