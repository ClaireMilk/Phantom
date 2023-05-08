using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Phantom
{
    public class TakePill : MonoBehaviour
    {
        public Text pillUI;

        // Update is called once per frame
        void Update()
        {
            bool doorOpen = LockDoor.doorOpen;
            bool lookPill = PlayerRayCastTest.lookPill;

            if(lookPill && doorOpen)
            {
                pillUI.enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    //add sound
                    Destroy(gameObject);
                    pillUI.enabled = false;
                    Invoke("Ending", 2.0f);
                }
            }
            else
            {
                pillUI.enabled = false;
            }
        }

        void Ending()
        {
            SceneManager.LoadScene(4);
        }
    }

}