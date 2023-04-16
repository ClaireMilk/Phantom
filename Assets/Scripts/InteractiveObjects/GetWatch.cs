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
        public static bool getWatch;

        public override void Awake()
        {
            stepOne.enabled = false;
            stepTwo.enabled = false;
            leftHandUI.SetActive(false);
            getWatch = false;
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
                    stepTwo.enabled = false;
                    leftHandUI.SetActive(true);
                    Destroy(gameObject);
                    isPause = false;
                    break;
                default:
                    break;
            }
        }

        public void LateUpdate()
        {
            if(i == 2)
                getWatch = true;
        }

        public void StepTwo()
        {
            transform.parent = cameraTransform;
            transform.localPosition = new Vector3(vector.x, vector.y, vector.z);
            transform.localRotation = Quaternion.Euler(-20, 0, 0);
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
    }
}
