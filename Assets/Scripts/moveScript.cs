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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            inputValue1 = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
            inputValue1 = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
            //transform.Rotate(0, rotSpeed * inputValue1.x * Time.deltaTime, 0);
            if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
                running = true;
            if (inputValue1.x == 0 && inputValue1.y == 0)
                running = false;
            if (running)
                transform.Translate(Time.deltaTime * fastSpeed * (inputValue1.y * new Vector3(camera.forward.x, 0, camera.forward.z) + inputValue1.x * new Vector3(camera.forward.z, 0, -camera.forward.x)));
            else
                transform.Translate(Time.deltaTime * speed * (inputValue1.y * new Vector3(camera.forward.x, 0, camera.forward.z) + inputValue1.x * new Vector3(camera.forward.z, 0, -camera.forward.x)));
        }
        

    }
}
