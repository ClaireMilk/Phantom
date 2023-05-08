using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class Radio : MonoBehaviour
    {
        public AudioSource radioSound;
        private bool b;

        // Update is called once per frame
        void Update()
        {
            bool canTurnRadio = PlayerRayCastTest.canTurnRadio;
            if(Input.GetKeyDown(KeyCode.E) && canTurnRadio)
            {
                if (!b)
                {
                    radioSound.Play();
                    b = !b;
                }
                else
                {
                    radioSound.Stop();
                    b = !b;
                }
            }
        }
    }
}