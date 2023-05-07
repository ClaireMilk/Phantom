using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class Airplane : MonoBehaviour
    {
        public GameObject flyAnim;
        public void AirplaneFly(int flyEvent)
        {
            if(flyEvent == 0)
            {
                flyAnim.SetActive(true);
            }
        }
    }
}
