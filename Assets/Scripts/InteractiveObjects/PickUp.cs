using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Phantom
{
    public class PickUp : MonoBehaviour
    {
        //pickup and put back
        public Transform cameraTransform;
        public Transform itemsTransform;
        public Vector3 vector;
        private Rigidbody rb;
        public static bool isPause;
        private Vector3 originalVector;

        //rotate object
        public int yMinLimit;
        public int yMaxLimit;
        public float xSpeed;
        public float ySpeed;
        protected float x, y;
        private bool canRotate;

        public virtual void Awake()
        {
            rb = GetComponent<Rigidbody>();
            isPause = false;
            canRotate = false;
            originalVector = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }

        public virtual void Update()
        {
            //if player is closed to the interactive items and look at it, can pickup it to check details
            bool canPickup = PlayerRayCastTest.canPickup;
            bool getWatch = GetWatch.getWatch;

            if (Input.GetKeyDown(KeyCode.E) && getWatch)
            {
                //Debug.Log(canPickup);
                if (canPickup && !canRotate)
                {
                    transform.parent = cameraTransform;
                    transform.localPosition = new Vector3(vector.x, vector.y, vector.z);
                    transform.localRotation = Quaternion.Euler(-20, 0, 0);
                    rb.isKinematic = true;
                    isPause = true;
                    canRotate = true;
                }
                else
                {
                    isPause = false;
                    transform.parent = itemsTransform;
                    transform.localPosition = new Vector3(originalVector.x, originalVector.y, originalVector.z);
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    canRotate = false;
                }
            }

            MouseControlObjectRotation();
        }

        private void MouseControlObjectRotation()
        {
            if (Input.GetMouseButton(0) && canRotate)
            {
                //get mouse x movement value
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
                y = ClampAngle(y, yMinLimit, yMaxLimit);
                Quaternion rotation = Quaternion.Euler(y, -x, 0);
                transform.rotation = rotation;
            }
        }

        static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360)
                angle += 360;
            if (angle > 360)
                angle -= 360;
            return Mathf.Clamp(angle, min, max);
        }
    }
}