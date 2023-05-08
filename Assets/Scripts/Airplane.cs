using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class Airplane : MonoBehaviour
    {
        public GameObject flyAnim;
        public GameObject anotherCamera;
        public GameObject airRaidDestroy;
        public GameObject blackUI;
        public GameObject explodeEffect;

        public void AirplaneFly(int flyEvent)
        {
            if (flyEvent == 2)
            {
                anotherCamera.SetActive(true);
            }
        }

        public void Explode(int flyEvent)
        {
            if(flyEvent == 0)
            {
                explodeEffect.SetActive(true);
            }
            if(flyEvent == 1)
            {
                blackUI.SetActive(true);
                Destroy(anotherCamera);
                Destroy(airRaidDestroy);
            }
        }
        public void PlaneDisappear(int flyEvent)
        {
            if (flyEvent == 3)
            {
                Destroy(explodeEffect);
                Destroy(blackUI);
                Destroy(flyAnim);
            }
        }
    }
}
