/*
 * This code use is part of Arcade Car Physics for Unity by Saarg (2018)
 */
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Noesis;
using Rover.ViewModels;
using Rover.Views;

namespace VehicleBehaviour.Utils
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Camera noesisCamera;
        
        //UI datacontext
        TelemetryScreenViewModel _context;

        //mouselook

        [SerializeField] string mouseLookInput = "Mouse Look";
        public float cameraSensitivity = 120;
        [HideInInspector] public bool allowMouseLook = true;
        bool mouseLook;
        public bool MouseLook { get { return mouseLook; } set { mouseLook = value; } }
        private float rotationX = 0.0f;
        private float rotationY = 0.0f;



        // Should the camera follow the target
        [SerializeField] bool follow = false;
        public bool Follow { get { return follow; } set { follow = value; } }

        // Current target
        [SerializeField] UnityEngine.Transform target;

        // ALl possible targets
        [SerializeField] UnityEngine.Transform[] targets;

        // Offset from the target position
        [SerializeField] Vector3 offset;

        // Camera speeds
        [Range(0, 10)]
        [SerializeField] float lerpPositionMultiplier = 1f;
        [Range(0, 10)]
        [SerializeField] float lerpRotationMultiplier = 1f;

        // Speedometer
       // [SerializeField] Text speedometer;

        // We use a rigidbody to prevent the camera from going in walls but it means sometime it can get stuck
        Rigidbody rb;
        Rigidbody target_rb;

        WheelVehicle vehicle;

        // скорость зума
        public float wheel_speed = 100f; 

        void Start()
        {
            rb = GetComponent<Rigidbody>();

            var view = noesisCamera.GetComponent<NoesisView>().Content;
            var telemetryview = (TelemetryScreenView)view.FindName("telemetryScreenView");
            _context = (TelemetryScreenViewModel)telemetryview.DataContext;

            SetTargetIndex(0);

        }

        // Select target from targets list using it's index
        public void SetTargetIndex(int i)
        {
            WheelVehicle v;

            foreach (UnityEngine.Transform t in targets)
            {
                v = t != null ? t.GetComponent<WheelVehicle>() : null;
                if (v != null)
                {
                    v.IsPlayer = false;
                    v.Handbrake = true;
                }
            }

            target = targets[i % targets.Length];

            vehicle = target != null ? target.GetComponent<WheelVehicle>() : null;
            if (vehicle != null)
            {
                vehicle.IsPlayer = true;
                vehicle.Handbrake = false;
            }
        }

        void FixedUpdate()
        {



            


            mouseLook = GetInput(mouseLookInput) > 0;

            if (mouseLook && allowMouseLook)
            {

                rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
                rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
                rotationY = Mathf.Clamp(rotationY, -90, 90);

                transform.rotation = Quaternion.AngleAxis(rotationX, Vector3.up);
                transform.rotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

            }
            else
            {
                // If we don't follow or target is null return
                if (!follow || target == null) return;

                // normalise velocity so it doesn't jump too far
                this.rb.velocity.Normalize();

                // Save transform localy
                Quaternion curRot = transform.rotation;
                Vector3 tPos = target.position + target.TransformDirection(offset);

                // Look at the target
                transform.LookAt(target);

                // Keep the camera above the target y position
                if (tPos.y < target.position.y)
                {
                    tPos.y = target.position.y;
                }

                // Set transform with lerp
                transform.position = Vector3.Lerp(transform.position, tPos, Time.fixedDeltaTime * lerpPositionMultiplier);
                transform.rotation = Quaternion.Lerp(curRot, transform.rotation, Time.fixedDeltaTime * lerpRotationMultiplier);

                // Keep camera above the y:0.5f to prevent camera going underground
                if (transform.position.y < 0.5f)
                {
                    transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
                }

                // Update speedometer
                if (vehicle != null)
                {
                    _context.Speed = (int)Mathf.Abs(vehicle.Speed);
                }
            }
            
            
            

           


            //отделение/приближение колесом мышки
            float mw = Input.GetAxis("Mouse ScrollWheel");
            if (mw != 0)
            { 
                offset.z += offset.z * Time.deltaTime * -mw * wheel_speed;
                offset.y += offset.y * Time.deltaTime * -mw * wheel_speed/2;

                if (offset.z > -10f)
                    offset.z = -10f;
                if (offset.y < 4.7f)
                    offset.y = 4.7f;

                if (offset.z < -30f)
                    offset.z = -30f;
                if (offset.y > 18f)
                    offset.y = 18f;
            }

           
        }

        private float GetInput(string input)
        {
            return Input.GetAxis(input);
        }
    }
}
