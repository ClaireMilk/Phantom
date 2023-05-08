using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class PlayerTransform : MonoBehaviour
    {
        public GameObject camera22;
        public Transform player1;
        public Transform player2;
        public Transform camera1;
        public Transform camera2;

        private void Update()
        {
            bool getWatch = GetWatch.getWatch;
            if (getWatch && Input.GetMouseButtonDown(1))
            {
                if (!camera22.activeInHierarchy)
                {
                    player2.transform.localEulerAngles = new Vector3(0, player1.transform.localEulerAngles.y, 0);
                    player2.transform.position = new Vector3(player1.position.x, 1, player1.position.z);
                    camera2.transform.localRotation = Quaternion.Euler(camera1.localRotation.x, 0, 0);
                }
                else if (camera22.activeInHierarchy)
                {
                    player1.transform.localEulerAngles = new Vector3(0, player2.transform.localEulerAngles.y, 0);
                    player1.transform.position = new Vector3(player2.position.x, 14, player2.position.z);
                    camera1.transform.localRotation = Quaternion.Euler(camera2.localRotation.x, 0, 0);
                }
            }
        }
    }
}