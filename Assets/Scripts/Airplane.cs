using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class Airplane : MonoBehaviour
    {
        public GameObject flyAnim;
        public GameObject hintUI;

        public void AirplaneFly(int flyEvent)
        {
            if(flyEvent == 0)
            {
                flyAnim.SetActive(true);
            }
            if(flyEvent == -1)
            {
                hintUI.SetActive(false);
            }
        }

        public void PlaneDisappear(int flyEvent)
        {
            if (flyEvent == 1)
            {
                flyAnim.SetActive(false);
            }
        }
    }
}
