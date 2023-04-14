// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;
//
// public class getQuaternionScript : MonoBehaviour
// {
//     // public Quaternion output;
//     public bool isReturns = true;
//     public float outputAngle;
//     // public Transform doll;
//
//     private HingeJoint _joint;
//     private XRGrabInteractable _grab;
//
//     private void Start()
//     {
//         _joint = GetComponent<HingeJoint>();
//         _grab = GetComponent<XRGrabInteractable>();
//     }
//
//     void Update()
//     {
//         if (_grab.isSelected)
//         {
//             outputAngle = _joint.angle;
//         }
//         else if (outputAngle != 0 && isReturns)
//         {
//             outputAngle = 0;
//         }
//         // output = doll.localRotation;
//         // if (output.x < 0.001f)
//         //     output.x = 0;
//         // if (output.y < 0.001f)
//         //     output.y = 0;
//         // if (output.z < 0.001f)
//         //     output.z = 0;
//     }
//     
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.XR.Interaction.Toolkit;
    
    public class getQuaternionScript : MonoBehaviour
    {
        // public Quaternion output;
        public bool isReturns = true;
        public float outputAngle;
        // public Transform doll;
        private bool justGrabbed = false;
        private HingeJoint _joint;
        private XRGrabInteractable _grab;

        private Quaternion startRot;
    
        private void Start()
        {
            _joint = GetComponent<HingeJoint>();
            _grab = GetComponent<XRGrabInteractable>();
            startRot = transform.localRotation;
    
            if (!isReturns)
            {
                // GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            }
        }
    
        void Update()
        {
            if (_grab.isSelected)
            {
                outputAngle = _joint.angle;
    
                if (!justGrabbed)
                {
                    if (!isReturns)
                    {
                        // transform.localRotation = startRot;
                        // GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    }
                    justGrabbed = true;
                }
            }
                
            else if (justGrabbed)
            {
                if (!isReturns)
                {
                    startRot = transform.localRotation;
                    // GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

                }
    
                else
                {
                    outputAngle = 0;
                }
                
                justGrabbed = false;
            }
            else
                transform.localRotation = startRot;
            
        }
    }

