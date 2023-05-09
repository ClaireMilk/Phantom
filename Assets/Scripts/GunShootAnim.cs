using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootAnim : MonoBehaviour
{
    public AudioSource gunShot;

    public void ShootAudio(int a)
    {
        if(a == 0)
            gunShot.Play();
    }
}
