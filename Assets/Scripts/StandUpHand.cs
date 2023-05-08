using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandUpHand : MonoBehaviour
{
    public AudioSource standUp;

    public void StandHand(int stand)
    {
        if(stand == 0)
            standUp.Play();
    }
}
