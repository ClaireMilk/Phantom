using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class FilePick : MonoBehaviour
    {
        public static bool isPause;
        public static bool reading;
        public GameObject content;
        public AudioSource checkMail;

        private void Update()
        {
            bool canRead = PlayerRayCastTest.canPickFile;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (canRead && !reading)
                {
                    checkMail.Play();
                    content.SetActive(true);
                    isPause = true;
                    reading = true;
                }
                else
                {
                    checkMail.Play();
                    content.SetActive(false);
                    isPause = false;
                    reading = false;
                }
            }
        }
    }
}
