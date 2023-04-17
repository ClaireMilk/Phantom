using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Phantom
{
    public class CabinetDoor : MonoBehaviour
    {
        private bool closedLeft = true;
        private bool closedRight = true;
        private bool b;

        // Update is called once per frame
        void Update()
        {
            bool seeingLeft = PlayerRayCastTest.canOpenCabinetDoor;
            bool seeingRight = PlayerRayCastTest.canOpenCabinetDoor_R;
            bool getWatch = GetWatch.getWatch;

            if (seeingLeft || seeingRight)
            {
                if (Input.GetKeyDown(KeyCode.E) && getWatch)
                {
                    b = true;
                }
            }
        }

        private void FixedUpdate()
        {
            if (b)
            {
                if (this.gameObject.CompareTag("CabinetDoor") && closedLeft)
                {
                    DoorControl_1(0, 80);
                    closedLeft = !closedLeft;
                    b = false;
                }
                else if (this.gameObject.CompareTag("CabinetDoor") && !closedLeft)
                {
                    DoorControl_2(80, 0);
                    closedLeft = !closedLeft;
                    b = false;
                }
                else if (this.gameObject.CompareTag("CabinetDoor_R") && closedRight)
                {
                    DoorControl_2(0, -80);
                    closedRight = !closedRight;
                    b = false;
                }

                else if (this.gameObject.CompareTag("CabinetDoor_R") && !closedRight)
                {
                    DoorControl_1(-80, 0);
                    closedRight = !closedRight;
                    b = false;
                }
            }
        }

        private void DoorControl_1(int a, int b)
        {          
            for(int i = a; i< b; i++)
            {
                transform.localRotation = Quaternion.Euler(0, i, 0);
            }
        }

        private void DoorControl_2(int a, int b)
        {
            for (int i = a; i > b; i--)
            {
                transform.localRotation = Quaternion.Euler(0, i, 0);
            }
        }
    }
}