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
        private Vector3 originalVector_p;
        private Vector3 originalVector_r;
        private GameObject[] checkedObjects;

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
            originalVector_p = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
            originalVector_r = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
            //Debug.Log(originalVector_r);
            checkedObjects = GameObject.FindGameObjectsWithTag("checkedItems");
        }

        public virtual void Update()
        {
            //if player is closed to the interactive items and look at it, can pickup it to check details
            bool canPickup = PlayerRayCastTest.canPickup;

            if (Input.GetKeyDown(KeyCode.E) && GameObject.FindGameObjectWithTag("Watch") == null)
            {
                //Debug.Log(canPickup);
                if (canPickup && !canRotate)
                {
                    transform.parent = cameraTransform;
                    transform.localPosition = new Vector3(vector.x, vector.y, vector.z);
                    transform.localRotation = Quaternion.Euler(-20, 180, 0);
                    rb.isKinematic = true;
                    isPause = true;
                    canRotate = true;
                }
                else
                {
                    isPause = false;
                    transform.parent = itemsTransform;
                    transform.localRotation = Quaternion.Euler(originalVector_r.x, originalVector_r.y, originalVector_r.z);
                    transform.localPosition = new Vector3(originalVector_p.x, originalVector_p.y, originalVector_p.z);
                    canRotate = false;

                    for (int i = 0; i < checkedObjects.Length; i++)
                    {
                        checkedObjects[i].GetComponent<PickUp>().enabled = false;
                    }
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