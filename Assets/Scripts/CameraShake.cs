using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Camera seeAirplane;
    public GameObject flyAnim;

    public void FieldOfView(int see)
    {
        if(see == 0)
        {
            for (int i = 60; i > 40; i--)
            {
                seeAirplane.fieldOfView = i;
            }
        }

        if (see == 1)
        {
            flyAnim.SetActive(true);
        }
    }
}
