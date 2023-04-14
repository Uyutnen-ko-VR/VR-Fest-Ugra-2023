using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    public Transform camera;
    Vector2 inputValue1, inputValue2;
    public bool canMove = true;
    bool running = false;
    public float speed = 1f, rotSpeed = 30f, fastSpeed = 3f;
    
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            inputValue1 = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
            inputValue2 = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
            Vector3 translateVector = camera.forward * inputValue2.y + camera.right * inputValue2.x;
            transform.Translate(Time.deltaTime * fastSpeed * new Vector3(-translateVector.z, 0, translateVector.x));
        }
        

    }
}
