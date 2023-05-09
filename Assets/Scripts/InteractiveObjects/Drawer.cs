using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class Drawer : MonoBehaviour
    {
        private bool closed = true;
        public float moveDistance;
        public AudioSource openDrawer;

        // Update is called once per frame
        void Update()
        {
            bool isSeeing = PlayerRayCastTest.canOpenDrawer;
            bool getWatch = GetWatch.getWatch;

            if (Input.GetKeyDown(KeyCode.E) && getWatch)
            {
                openDrawer.Play();
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

        void DrawerOpen()
        {

        }
    }
}
