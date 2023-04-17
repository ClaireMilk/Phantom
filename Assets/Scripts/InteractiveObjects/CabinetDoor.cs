using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Phantom
{
    public class CabinetDoor : MonoBehaviour
    {
        private bool closed = true;

        // Update is called once per frame
        void Update()
        {
            bool isSeeing = PlayerRayCastTest.canOpenCabinetDoor;

            if (Input.GetKeyDown(KeyCode.E) && GameObject.FindGameObjectWithTag("Watch") == null)
            {
                if (isSeeing && closed)
                {
                    transform.localRotation = Quaternion.Euler(0, 80, 0);
                    closed = false;
                }
                else if (isSeeing && !closed)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    closed = true;
                }
            }

        }
    }
}