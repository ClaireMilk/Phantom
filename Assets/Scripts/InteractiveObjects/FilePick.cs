using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Phantom
{
    public class FilePick : MonoBehaviour
    {
        public static bool isPause;
        public static bool reading;
        public GameObject content;
        public Text fileHint;

        private void Update()
        {
            bool canRead = PlayerRayCastTest.canPickFile;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (canRead && !reading)
                {
                    content.SetActive(true);
                    isPause = true;
                    reading = true;
                }
                else
                {
                    content.SetActive(false);
                    isPause = false;
                    reading = false;
                }
            }

            if(canRead && !reading)
            {
                fileHint.enabled = true;
            }
            else
            {
                fileHint.enabled = false;
            }
        }
    }
}
