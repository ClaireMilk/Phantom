using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Phantom
{
    public class PhotoSound : MonoBehaviour
    {
        public AudioSource memorySound;
        public Text soundUI;
        public AudioSource warBGM;
        public GameObject camera2;

        private void OnTriggerEnter(Collider other)
        {
            bool getWatch = GetWatch.getWatch;

            if (other.gameObject.tag == "Player" && getWatch)
            {
                if (!camera2.activeInHierarchy)
                {
                    Debug.Log("1");
                    soundUI.enabled = true;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        warBGM.volume = warBGM.volume * 0.2f;
                        memorySound.Play();
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                soundUI.enabled = false;
                memorySound.Stop();
                warBGM.volume = warBGM.volume * 5.0f;
            }
        }
    }
}