using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Phantom
{
    public class LockDoor : MonoBehaviour
    {
        public Text lockedUI;
        public GameObject brokenDoor;
        public static bool doorOpen;

        // Update is called once per frame
        void Update()
        {
            bool lookDoor = PlayerRayCastTest.lookLockDoor;
            bool haveShovel = GetShovel.getShovel;

            if(Input.GetKeyDown(KeyCode.E) && lookDoor)
            {
                if (!haveShovel)
                {
                    lockedUI.enabled = true;
                    Invoke("CloseUI", 1.0f);
                }
                else
                {
                    //add sound
                    doorOpen = true;
                    brokenDoor.SetActive(true);
                    Destroy(gameObject);
                }
            }
            else if (!lookDoor)
            {
                lockedUI.enabled = false;
            }
        }

        void CloseUI()
        {
            lockedUI.enabled = false;
        }
    }
}