using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Phantom
{
    public class GetWatch : PickUp
    {
        private int i = 0;
        public Text stepOne;
        public Text stepTwo;
        public GameObject leftHandUI;
        private bool startTakeWatch;
        public static bool getWatch;
        private Vector3 originalPosition;
        public Transform world;

        public override void Awake()
        {
            stepOne.enabled = false;
            stepTwo.enabled = false;
            leftHandUI.SetActive(false);
            startTakeWatch = true;
            getWatch = false;
            originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        public override void Update()
        {
            bool canPickup = PlayerRayCastTest.canPickupWatch;

            if (Input.GetKeyDown(KeyCode.E) && canPickup)
                i++;
            else if(canPickup)
                stepOne.enabled = true;
            else
                stepOne.enabled = false;

            //let player hold the watch
            if (startTakeWatch)
            {
                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        stepOne.enabled = false;
                        stepTwo.enabled = true;
                        StepTwo();
                        MouseControlObjectRotation();
                        break;
                    case 2:
                        stepOne.enabled = false;
                        stepTwo.enabled = false;
                        leftHandUI.SetActive(true);
                        transform.parent = world;
                        transform.localRotation = Quaternion.Euler(-90, 0, 0);
                        transform.position = originalPosition;
                        isPause = false;
                        getWatch = true;
                        startTakeWatch = false;
                        Invoke("TakeWatch", 1.1f);
                        break;
                    default:
                        break;
                }
            }
        }

        public void StepTwo()
        {
            transform.parent = cameraTransform;
            transform.localPosition = new Vector3(vector.x, vector.y, vector.z);
            isPause = true;
        }

        public void MouseControlObjectRotation()
        {
            if (Input.GetMouseButton(0))
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

        void TakeWatch()
        {
            Destroy(gameObject);
            Destroy(stepOne);
        }
    }
}
