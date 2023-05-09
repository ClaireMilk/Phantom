using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class FootstepAudio : MonoBehaviour
    {
        public GameObject foot_R;
        public GameObject foot_N;
        public GameObject camera2;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            if (!camera2.activeInHierarchy)
            {
                if (x > 0.01f || x < -0.01f)
                {
                    foot_N.SetActive(true);
                }
                else if (z > 0.01f || z < -0.01f)
                    foot_N.SetActive(true);
                else
                    foot_N.SetActive(false);
            }
            else if (camera2.activeInHierarchy)
            {
                if (x > 0.01f || x < -0.01f)
                {
                    foot_R.SetActive(true);
                }
                else if (z > 0.01f || z < -0.01f)
                    foot_R.SetActive(true);
                else
                    foot_R.SetActive(false);
            }

        }
    }
}