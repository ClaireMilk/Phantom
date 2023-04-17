using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class Drawer : MonoBehaviour
    {
        private bool closed = true;
        public float moveDistance;

        // Update is called once per frame
        void Update()
        {
            bool isSeeing = PlayerRayCastTest.canOpenDrawer;

            if (Input.GetKeyDown(KeyCode.E) && GameObject.FindGameObjectWithTag("Watch") == null)
            {
                if (isSeeing && closed)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, (transform.localPosition.z + moveDistance));
                    closed = false;
                }
                else if (isSeeing && !closed)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, (transform.localPosition.z - moveDistance));
                    closed = true;
                }
            }

        }
    }
}
