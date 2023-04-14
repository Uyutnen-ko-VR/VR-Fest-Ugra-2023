using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    public Transform camera, pivot, lookAt;
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
            // transform.Rotate(0, rotSpeed * inputValue1.x * Time.deltaTime, 0);
            lookAt.LookAt(pivot);
            if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
                running = true;
            if (inputValue2.x == 0 && inputValue2.y == 0)
                running = false;
            Vector3 translateVector = camera.forward * inputValue2.y + camera.right * inputValue2.x;
            // if (running)
            transform.Translate(Time.deltaTime * fastSpeed * new Vector3(-translateVector.z, 0, translateVector.x));
            //     transform.Translate(Time.deltaTime * fastSpeed * (inputValue2.y * new Vector3(camera.forward.x, 0, camera.forward.z) + inputValue2.x * new Vector3(camera.forward.z, 0, -camera.forward.x)));
            // else
                // transform.Translate(Time.deltaTime * speed * (inputValue2.y * new Vector3(camera.forward.x, 0, camera.forward.z) + inputValue2.x * new Vector3(pivot.forward.z, 0, -pivot.forward.x)));
        }
        

    }
}
