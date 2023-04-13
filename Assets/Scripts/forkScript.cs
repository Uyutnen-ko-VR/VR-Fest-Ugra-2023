using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forkScript : MonoBehaviour
{
    public getQuaternionScript upDownLever, leftRightLever;
    public Vector2 minMaxForkHeight, minMaxForkWeight;

    public GameObject smallHandler, bigHandler;

    private void Update()
    {
        var newHeight = ConvertToDiapason(upDownLever.outputAngle, -90, 90, minMaxForkHeight[0], minMaxForkHeight[1]);
        var newWeight = ConvertToDiapason(leftRightLever.outputAngle, -90, 90, minMaxForkWeight[0], minMaxForkWeight[1]);
        
        print(newHeight + " | " + newWeight);

        smallHandler.transform.localPosition = new Vector3(0, newHeight, 0);
        bigHandler.transform.localPosition = new Vector3(0, 0, newWeight);
    }
    
    private float ConvertToDiapason(float old, float oldMin, float oldMax, float newMin, float newMax)
    {
        float oldRange = oldMax - oldMin;
        float newRange = newMax - newMin;
        float converted = ((old - oldMin) * newRange / oldRange) + newMin;

        return converted;
    }

}


// {
//     public Transform forkHandler;
//     public float forkValue = 0, minForkHeight, maxForkHeight;
//     float prevForkValue;
//     public getQuaternionScript leverValue;
//     public enum axis
//     {
//         X, Y, Z, aX, aY, aZ
//     };
//     public axis leverAxis, forkAxis;
//     void Start()
//     {
//         prevForkValue = forkValue;
//     }
//
//     void Update()
//     {
//         
//         switch (leverAxis)
//         {
//             case axis.X:
//                 forkValue += leverValue.output.x;
//                 break;
//             case axis.Y:
//                 forkValue += leverValue.output.y;
//                 break;
//             case axis.Z:
//                 forkValue += leverValue.output.z;
//                 break;
//             case axis.aX:
//                 forkValue -= leverValue.output.x;
//                 break;
//             case axis.aY:
//                 forkValue -= leverValue.output.y;
//                 break;
//             case axis.aZ:
//                 forkValue -= leverValue.output.z;
//                 break;
//         }
//         forkValue = Mathf.Clamp(forkValue, minForkHeight, maxForkHeight);
//         switch (forkAxis)
//         {
//             case axis.X:
//                 forkHandler.Translate((forkValue - prevForkValue) * Time.deltaTime, 0, 0);
//                 break;
//             case axis.Y:
//                 forkHandler.Translate(0, (forkValue - prevForkValue) * Time.deltaTime, 0);
//                 break;
//             case axis.Z:
//                 forkHandler.Translate(0, 0, (forkValue - prevForkValue) * Time.deltaTime);
//                 break;
//             case axis.aX:
//                 forkHandler.Translate((forkValue - prevForkValue) * -Time.deltaTime, 0, 0);
//                 break;
//             case axis.aY:
//                 forkHandler.Translate(0, (forkValue - prevForkValue) * -Time.deltaTime, 0);
//                 break;
//             case axis.aZ:
//                 forkHandler.Translate(0, 0, (forkValue - prevForkValue) * -Time.deltaTime);
//                 break;
//         }
//         prevForkValue = forkValue;
//     }
// }
