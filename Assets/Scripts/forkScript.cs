using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forkScript : MonoBehaviour
{
    public Transform forkHandler;
    public float forkValue = 0, minForkHeight, maxForkHeight;
    float prevForkValue;
    public getQuaternionScript leverValue;
    public enum axis
    {
        X, Y, Z, aX, aY, aZ
    };
    public axis leverAxis, forkAxis;
    void Start()
    {
        prevForkValue = forkValue;
    }

    void Update()
    {
        
        switch (leverAxis)
        {
            case axis.X:
                forkValue += leverValue.output.x;
                break;
            case axis.Y:
                forkValue += leverValue.output.y;
                break;
            case axis.Z:
                forkValue += leverValue.output.z;
                break;
            case axis.aX:
                forkValue -= leverValue.output.x;
                break;
            case axis.aY:
                forkValue -= leverValue.output.y;
                break;
            case axis.aZ:
                forkValue -= leverValue.output.z;
                break;
        }
        forkValue = Mathf.Clamp(forkValue, minForkHeight, maxForkHeight);
        switch (forkAxis)
        {
            case axis.X:
                forkHandler.Translate((forkValue - prevForkValue) * Time.deltaTime, 0, 0);
                break;
            case axis.Y:
                forkHandler.Translate(0, (forkValue - prevForkValue) * Time.deltaTime, 0);
                break;
            case axis.Z:
                forkHandler.Translate(0, 0, (forkValue - prevForkValue) * Time.deltaTime);
                break;
            case axis.aX:
                forkHandler.Translate((forkValue - prevForkValue) * -Time.deltaTime, 0, 0);
                break;
            case axis.aY:
                forkHandler.Translate(0, (forkValue - prevForkValue) * -Time.deltaTime, 0);
                break;
            case axis.aZ:
                forkHandler.Translate(0, 0, (forkValue - prevForkValue) * -Time.deltaTime);
                break;
        }
        prevForkValue = forkValue;
    }
}
