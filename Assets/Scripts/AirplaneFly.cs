using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class AirplaneFly : MonoBehaviour
    {
        public GameObject airplaneAnim;

        public void ShowAirplane(int isShow)
        {
            if (isShow == 1) // start showing the air raid animation
            {
                airplaneAnim.SetActive(true);
            }
        }
    }
}
