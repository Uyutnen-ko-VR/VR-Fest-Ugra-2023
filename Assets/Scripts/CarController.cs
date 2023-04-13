using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    public getQuaternionScript steering, drive;

    private Rigidbody _rb => GetComponent<Rigidbody>();
    public GameObject particles, deathScreen;
    
    public enum inputEnum
    {
        keyboard,
        vr
    }

    public inputEnum input;


    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }


    private void GetInput()
    {
        switch (input)
        {
            case inputEnum.keyboard:
                horizontalInput = Input.GetAxis(HORIZONTAL);
                verticalInput = Input.GetAxis(VERTICAL);
                isBreaking = Input.GetKey(KeyCode.Space);
                break;
            case inputEnum.vr:
                horizontalInput = -ConvertToDiapason(steering.outputAngle, -45, 45, -1, 1);
                verticalInput = ConvertToDiapason(drive.outputAngle, -45, 45, -1, 1);
                
                isBreaking = verticalInput == 0;

                break;
        }


        // horizontalInput = -ConvertToDiapason(steering.output.x, -0.7f, 0.7f, -1, 1);
        // verticalInput = ConvertToDiapason(drive.output.x, -0.7f, 0.7f, -1, 1);

    }

    private float ConvertToDiapason(float old, float oldMin, float oldMax, float newMin, float newMax)
    {
        float oldRange = oldMax - oldMin;
        float newRange = newMax - newMin;
        float converted = ((old - oldMin) * newRange / oldRange) + newMin;

        return converted;
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();       
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot
;       wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    private void OnCollisionEnter(Collision other)
    {
        print(_rb.velocity.magnitude);
        if (_rb.velocity.magnitude > 0.5)
        {
            particles.SetActive(true);
            Invoke(nameof(ShowDeathScreen), 10f);
            Invoke(nameof(ReloadScene), 15f);

            print("Destruct");
        }
    }

    private void ShowDeathScreen()
    {
        deathScreen.SetActive(true);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
