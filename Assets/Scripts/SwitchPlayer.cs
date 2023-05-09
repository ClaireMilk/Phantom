using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class SwitchPlayer : MonoBehaviour
    {
        public GameObject player1;
        public GameObject player2;
        private bool b1 = true, b2 = true;
        public static bool inRealWorld;
        public float delayTime;
        private bool isAnim = false;
        private Animator anim;
        public GameObject tutorial;
        public GameObject audioR;
        public GameObject audioN;
        public static bool bgmControl;

        private void Awake()
        {
            player1.SetActive(b1);
            player2.SetActive(!b1);
            anim = GetComponent<Animator>();
            inRealWorld = true;
        }

        void Update()
        {
            //Switch the two different world
            if (Input.GetMouseButtonDown(1) && b2)
            {
                isAnim = true;
                b2 = !b2;
                Invoke("SwitchScene", delayTime);
                inRealWorld = !inRealWorld;
            }
        }

        private void FixedUpdate()
        {
            // start left hand turn on/off watch animation
            if (isAnim)
            {
                anim.SetBool("isOn", !b1);
            }
        }

        //Swicth camera
        private void SwitchScene()
        {
            if (tutorial != null)
                Destroy(tutorial);
            player1.SetActive(b1);
            player2.SetActive(!b1);

            audioR.SetActive(bgmControl);
            audioN.SetActive(!bgmControl);
            bgmControl = !bgmControl;
            b1 = !b1;
            b2 = !b2;
            isAnim = false;
        }

    }
}
